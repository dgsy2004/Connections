using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

/// think of a way to make this into selecting different academic categories of words, i.e. CS, bio, physics, etc.
public partial class GameBoard : Control
{
	[Export] PackedScene btnScene;
	[Export] int gameBoardWidth = 4;
	[Export] int gameBoardHeight = 4;
	[Export] string[] simpleWords;
	[Export] string[] mediumWords;
	[Export] string[] hardWords;
	[Export] string[] complexWords;

	List<string> allWords = new List<string>();
	List<string> randomizedList = new List<string>();

	private void AppendWords()
	{
		for (int i = 0; i < simpleWords.Length; i++)
		{
			allWords.Add(simpleWords[i]);
		}
		
		for (int i = 0; i < mediumWords.Length; i++)
		{
			allWords.Add(mediumWords[i]);
		}
		
		for (int i = 0; i < hardWords.Length; i++)
		{
			allWords.Add(hardWords[i]);
		}

		for (int i = 0; i < complexWords.Length; i++)
		{
			allWords.Add(complexWords[i]);
		}
	}
	
	Button completeList;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AppendWords();
		ShuffleWords();
		
		for (int x = 0; x < gameBoardWidth; x++)
		{
			for (int y = 0; y < gameBoardHeight; y++)
			{
				Button newButton = btnScene.Instantiate<Button>();		
				AddChild(newButton);
				

				newButton.Position = new Vector2(newButton.Size.X * x, newButton.Size.Y * y);
				newButton.Size = new Vector2(newButton.Size.X * .9f, newButton.Size.Y * .9f);
				newButton.Position = new Vector2(newButton.Position.X + (newButton.Size.X *.05f), newButton.Position.Y + (newButton.Size.Y * .05f));

				newButton.Text = GetButtonWord();
			}
		}
	}


	private void ShuffleWords()
	{
		int iterations = allWords.Count;
		for (int i = 0; i < iterations; i++)
		{
			int randomNumber = GD.RandRange(0, allWords.Count-1);
			randomizedList.Add(allWords[randomNumber]);
			allWords.RemoveAt(randomNumber);
		}
	}

	private string GetButtonWord()
	{
		string word = randomizedList[0];
		randomizedList.RemoveAt(0);
		return word;
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
