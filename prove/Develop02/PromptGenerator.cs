using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> __prompts;

    public PromptGenerator()
    {
        __prompts = new List<string>
        {
            "How was your day?",
            "How was your night?",
            "How was your afternoon?",
            "What could you have done better today?",
            "What made you happy today?",
            "How are you feeling today?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(__prompts.Count);
        return __prompts[promptIndex];
    }
}
