let decompose (str:string) = 
    match str with
    | str when str.StartsWith("//") ->
            let delim = str.[2]
            ([| delim |], str.[3..])
    | str -> ([| ',';'\n' |], str)
   
let add str = 
    match str with
    | "" -> 0
    | str -> 
            let delim, numbers = decompose str
            numbers.Split(delim) |> Array.map int |> Array.sum

//The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
let r1 = add "" = 0
let r2 = add "100" = 100
let r3 = add "1,2" = 3
let r4 = add "1,2,3" = 6
//.Allow the Add method to handle new lines between numbers (instead of commas).the following input is ok:  “1\n2,3”  (will equal 6)
let r5 = add "1\n2,3" = 6
//Support different delimiters  “//[delimiter]\n[numbers…]”  “//;\n1;2” should return three where the default delimiter is ‘;’ .
let r6 = add "//-\n1-2" = 3
let r7 = add "//;\n1;2;3" =6
//Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed
//if there are multiple negatives, show all of them in the exception message
let r8 = add "1,-2,-3" = 1
