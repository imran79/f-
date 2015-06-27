// Immutability Example
let square x = x * x

let imperativeSum numbers = 
    let mutable total = 0
    for i in numbers do
        let x = square i
        total <- total + x
        total

let functionalSum numbers = 
    numbers
    |> Seq.map square
    |> Seq.sum

// Function Values
let negate x = -x

List.map negate [ 1..10 ]

// Partial Function Values
let functionWithMultipleArg (value : string) (num : int) = value
let partialFunc = functionWithMultipleArg ("check")

partialFunc 5
// InLine Partial Functial
List.iter (fun i -> printfn "%d" i) [ 1..10 ]

// Function returning function
let generatePowerOfFunc baseValue = (fun exponent -> baseValue ** exponent)

// --------------  RECURSIVE FUNCTIONS ------------------- /
// 1- imperative style recursive function
let rec factorial x = 
    if x <= 1 then 1
    else x * factorial (x - 1)

//2- functional for loop 
let rec forLoop body times = 
    if times <= 0 then ()
    else 
        body()
        forLoop body (times - 1)

forLoop (fun () -> printfn "absolutely crazy stuff is f#") 3

//3- functional while loop
let rec whileLoop predicate body = 
    if predicate() then 
        body()
        whileLoop predicate body
    else ()

open System

whileLoop (fun () -> DateTime.Now.DayOfWeek <> DayOfWeek.Sunday) 
    (fun () -> printfn "i wish every day should be weekend")

// 4- Mutual recursive functions
let rec isOdd x = 
    if x = 0 then false
    elif x = 1 then true
    else isEven (x - 1)

and isEven x = 
    if x = 0 then true
    elif x = 1 then false
    else isOdd (x - 1)

isOdd 341

//------------------SYMBOLIC OPERATOR-------
// defining ! as factorial
let rec (!) x = 
    if x = 1 then 1
    else x * !(x - 1)

!5

// defining === as regular expression checker
open System.Text.RegularExpressions

let (===) str (regExp : string) = Regex.Match(str, regExp)

"The quick brown fox" === "The (.*) fox"

//-------------------Function  Composition ---------
// with out using function compositon let try to find out size of the folder
open System
open System.IO

let sizeOfFolder x = 
    let fileNames : string [] = Directory.GetFiles(x, ".*", SearchOption.AllDirectories)
    let fileInfos : FileInfo [] = Array.map (fun (file : string) -> new FileInfo(file)) fileNames
    let fileSizes : int64 [] = Array.map (fun (fileInfo : FileInfo) -> fileInfo.Length) fileInfos
    let totalSize = Array.sum fileSizes
    totalSize

printfn "%d" (sizeOfFolder "E:\\naat")

// use function composition
let sizeOfProvidedFolder x = 
    Array.sum 
        (Array.map (fun (fileInfo : FileInfo) -> fileInfo.Length) 
             (Array.map (fun (file : string) -> new FileInfo(file)) 
                  (Directory.GetFiles(x, ".*", SearchOption.AllDirectories))));;

//Pipe Forward Operator
let sizeOfFolder folder =
    let getFiles path : string[] =
        Directory.GetFiles(path, ".*", SearchOption.AllDirectories)
    let totalSize = 
        folder
        |> getFiles 
        |>Array.map (fun file  -> new FileInfo(file))
        |>Array.map (fun fileInfo  -> fileInfo.Length)                
        |>Array.sum ;;
                       
        totalSize;;


["Imran"; "Khan"] |> List.iter (fun s -> printfn "length of the string %d" s.Length)

// Foward Composition operator >>    let (>>) f g x = g(f x)
open System.IO
let sizeOfFolder ()  =
    let getFiles path : string[] =
        Directory.GetFiles(path, ".*", SearchOption.AllDirectories)
        
        getFiles 
        >>Array.map (fun file  -> new FileInfo(file))
        >>Array.map (fun fileInfo  -> fileInfo.Length)                
        >>Array.sum ;;

// basic forward composition
let square x = x *x
let toString (x : int) = x.ToString()
let strLen (s : String) = s.Length
let lenOfSquare = square >> toString >> strLen;;
lenOfSquare 63;;
                       
  // Pipe backward operator let (<|) f g x = f(g x) its use is more to pass the function result into other function
  
  // basic 
   printf "this is how with out backword pipe operator work %s" (sprintf "(%d,%d)" 1 2);;

    printf "this is how with  backword pipe operator work %s" <| sprintf "(%d,%d)" 1 2;;
       