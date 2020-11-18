export namespace TypescriptInteropExample {
    export class TypescriptInterop {
        public static showPrompt(message: string): string {
            return prompt(message, 'Type anything here');
        }
    }
}