module Day4

open System.Text.RegularExpressions

type Board = {
    numbers : int[]
    markedIndexes: int[]
}
let testMoves = "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1"
let testBoards = [|
    "22 13 17 11  0";
    " 8  2 23  4 24";
    "21  9 14 16  7";
    " 6 10  3 18  5";
    " 1 12 20 15 19";
    "";
    " 3 15  0  2 22";
    " 9 18 13 17  5";
    "19  8  7 25 23";
    "20 11 10 24  4";
    "14 21 16 12  6";
    "";
    "14 21 17 24  4";
    "10 16 15  9 19";
    "18  8 23 26 20";
    "22 11 13  6  5";
    " 2  0 12  3  7";
|]

let appendStringToArray state line  =
    let numbersMatches = Regex.Matches(line, "[0-9]+")
    let numbers = seq {
                            for number in numbersMatches do
                                yield (number.Value |> int)
                        }
    Array.append state (Array.ofSeq numbers)

let toBoard lines =
    Array.fold appendStringToArray Array.empty lines

let parseMoves input =
    let matches = Regex.Matches(input, "[0-9]+")
    seq { for _match in matches do yield _match.Value |> int } |> Array.ofSeq

let mark board number =
    let mutable i = 0
    let mutable result = board
    while i < board.numbers.Length do
        if (board.numbers[i] = number) then
            result <- {board with markedIndexes = Array.append board.markedIndexes [|i|]}
            i <- board.numbers.Length
        else i <- i + 1
    result
   
let checkBoard board =
    let markedIndexes = board.markedIndexes
    // TOOD
    ()
    
let run () =
    let moves = parseMoves testMoves
    let boards = seq {
        for i in 0 .. 6 .. (testBoards.Length-1) do
            let boardInput = testBoards[i..i+4]
            let board = {numbers = toBoard boardInput; markedIndexes = Array.empty}
            board
    } 
    
    let testBoard = boards |> Array.ofSeq |> Array.head
    
    let modifiedBoard = mark testBoard moves[0]
    
    ()
