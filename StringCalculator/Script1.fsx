let add str = 
    match str with
    | "" -> 0
    | _ when str.StartsWith("//") -> 
                let delim = str.[2]
                str.[3..].Split(delim) |> Array.map int |> Array.sum
       
    | _ -> str.Split(',', '\n') |> Array.map int |> Array.sum

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
