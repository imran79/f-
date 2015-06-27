// printing Hello World
printfn "Hello World"

//printing Date Time
open System;
let dateTime = System.DateTime.Now.ToShortDateString() 
printfn "%s, %s at %s"  dateTime

// declaring the varaibles
let x = 1

// declaring the functions
let add x y = x + y
add 2 2


let addFloat(x : float)  y = x + y;;
addFloat  1.0 2.0

let genericFunc(x : 'a)  = x ;;
genericFunc 1

genericFunc 2.0 

genericFunc "test with it"

let IsEven x = 
      if x % 2 = 0
       then
         printfn "Its Even"
         else
         printfn "No its not"
;;

  IsEven 25;;


  // CORE TYPES
  // tuples
  let snacks = ("cookies","candy")
  let  a, b = snacks;;


 


