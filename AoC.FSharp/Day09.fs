namespace AoC.FSharp

module Day09 =
    type public State = {
        sc: int
        n: int
        g: int
        isg: bool
        neg: bool
    }

    let folder state c =
        if state.neg then
            { sc = state.sc; n = state.n; g = state.g; isg = state.isg; neg = false }
        elif state.isg then
            if c = '>' then
                { sc = state.sc; n = state.n; g = state.g; isg = false; neg = state.neg }
            elif c = '!' then
                { sc = state.sc; n = state.n; g = state.g; isg = state.isg; neg = true }
            else
                { sc = state.sc; n = state.n; g = state.g + 1; isg = state.isg; neg = state.neg }
        else
            if c = '{' then
                { sc = state.sc; n = state.n + 1; g = state.g; isg = state.isg; neg = state.neg }
            elif c = '}' then
                let oldN = state.n
                { sc = state.sc + oldN; n = oldN - 1; g = state.g; isg = state.isg; neg = state.neg }
            elif c = '<' then
                { sc = state.sc; n = state.n; g = state.g; isg = true; neg = state.neg }
            else
                state

    let solve (s: string) =
        let startingState = { sc = 0; n = 0; g = 0; isg = false; neg = false }
        let chars = Seq.map(fun c -> c) s
        let finalState = Seq.fold folder startingState chars
        
        finalState
