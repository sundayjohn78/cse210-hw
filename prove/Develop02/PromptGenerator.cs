using System;
public class PromptGenerator
{
    public List<string> __prompts;

 public string GetRandomPrompt()
    {
        List<string> promptList = new List<string>
        {
            "How was your day?",
            "How was your night?",
            "How was your afternoon?"
        };

        Random random = new Random();
        int promptIndex = random.Next(promptList.Count);
        string selectedPrompt = promptList[promptIndex];
        return selectedPrompt;
    }
}