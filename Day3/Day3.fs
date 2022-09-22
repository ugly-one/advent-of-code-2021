module Day3
open Day3_input


let run = 
    let resultSize = Array2D.length2 input
    let bitsPerColumns = Array2D.length1 input
    let half = bitsPerColumns / 2

    let mostCommonBits = seq {
        for i in 0..(resultSize - 1) do
            let data = input[*,i]
            let sum = Array.sum data
            if (sum > half) then 1 else 0
    }

    let (gamma, epsilon, _) = Seq.foldBack (fun item (gamma,epsilon, index) ->  ((if item = 1 then gamma + pown 2 index else gamma),(if item = 0 then epsilon + pown 2 index else epsilon), index + 1)) mostCommonBits (0, 0, 0)
    gamma * epsilon