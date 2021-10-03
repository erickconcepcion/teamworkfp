namespace Utils
open System

module Utilities =
    let GetHiddenConsoleInput message = 
        printf "%s \n" message
        let appendChar string char = sprintf "%s%c" string char
        let removeLastChar (string: string) = string.Remove((String.length string) - 1)
        let keysBehavior string (key: ConsoleKeyInfo) = 
            if key.Key = ConsoleKey.Backspace && (String.length string) > 0 
            then removeLastChar string else appendChar string key.KeyChar
        let rec typing state =
            let key = Console.ReadKey true
            let noEnterValue (key: ConsoleKeyInfo) value newValue: string = if key.Key <> ConsoleKey.Enter then newValue else value
            let ret = noEnterValue key (keysBehavior state key) state
            noEnterValue key (typing ret) ret
        typing ""