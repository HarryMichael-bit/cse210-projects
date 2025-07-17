using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        int hidden = 0;
        while (hidden < count && HasVisibleWords())
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hidden++;
            }
        }
    }

    public bool IsFullyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }

    public bool HasVisibleWords()
    {
        return _words.Exists(w => !w.IsHidden());
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetDisplayText());
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine("\n");
    }
    public void RevealHint()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                // Reveal the first hidden word found
                word.Reveal();
                break;
            }
        }
    }
}