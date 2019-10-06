let add inputString = 
    match inputString with
    | "" -> 0
    | _ -> inputString.Split(',', '\n') |> Array.map int |> Array.sum

//The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
let r1 = add "" = 0
let r2 = add "100" = 100
let r3 = add "1,2" = 3
let r4 = add "1,2,3" = 6
//.Allow the Add method to handle new lines between numbers (instead of commas).the following input is ok:  “1\n2,3”  (will equal 6)
let r5 = add "1\n2,3" = 6
