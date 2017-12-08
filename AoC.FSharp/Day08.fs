namespace AoC.FSharp

module Day08 =
    type Instruction = {
        Reg: string;
        Op: string;
        X: int;
        CReg: string;
        COp: string;
        CX: int;
    }

    let parse (line: string) =
        let parts = line.Split(' ')
        let reg = parts.[0]
        let op = parts.[1]
        let x = int parts.[2]
        let cReg = parts.[4]
        let cOp = parts.[5]
        let cX = int parts.[6]

        { Reg = reg; Op = op; X = x; CReg = cReg; COp = cOp; CX = cX }
    
    let matches instruction v =
        let cx = instruction.CX
        match instruction.COp with
        | "==" -> v = cx
        | "!=" -> not (v = cx)
        | "<" -> v < cx
        | "<=" -> v <= cx
        | ">" -> v > cx
        | ">=" -> v >= cx
        | _ -> failwith "unexpected operator"

    let isApplicable instruction state =
        let (reg, value) = Seq.find (fun (r, v) -> r = instruction.CReg) state
        matches instruction value

    let getNewValue v instruction =
        if instruction.Op = "inc" then v + instruction.X else v - instruction.X

    let calculate r v instruction (state: list<string * int>) =
        if r = instruction.Reg && (isApplicable instruction state) then 
            getNewValue v instruction
        else 
            v

    let apply (state: list<string * int>) (instruction: Instruction) =
        List.map (fun (r, v) -> (r, calculate r v instruction state)) state

    let solve indata = 
        let instructions = Seq.map parse indata |> Seq.toList
        let emptyRegisters = List.map (fun i -> (i.Reg, 0)) instructions

        let state = List.fold (fun s i -> apply s i ) emptyRegisters instructions
        let max = List.max (List.map (fun (r, v) -> v) state)

        max

        