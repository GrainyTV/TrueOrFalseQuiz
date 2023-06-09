Console.OutputEncoding = System.Text.Encoding.UTF8;
List<Data> d1 = new List<Data>();
StreamReader r1 = new StreamReader("input.txt");

do
{
	string? line = r1.ReadLine();

	if (string.IsNullOrEmpty(line) == false)
	{
		string[] tmp = line.Split(';');
		Data tmp2 = new();
		tmp2.Question = tmp[0];
		tmp2.Answer = (tmp[1].Equals("I")) ? true : false;
		d1.Add(tmp2);
	}

} while (r1.EndOfStream != true);

r1.Close();
d1.Sort((x, y) => x.Question.CompareTo(y.Question));
List<Data> d2 = new List<Data>();
List<bool> guesses = new List<bool>();

for (int i = 0; i < d1.Count; ++i)
{
	Console.WriteLine("{0}.) {1} {2}", i + 1, d1.ElementAt(i).Question, d1.ElementAt(i).Fordito());
}

Console.ReadKey();
Console.Clear();
Random Random = new Random();

do
{
	int random = Random.Next(0, d1.Count);

	if (d2.Contains(d1.ElementAt(random)) != true)
	{
		d2.Add(d1.ElementAt(random));
	}

} while (d2.Count != d1.Count);

for (int i = 0; i < d2.Count; ++i)
{
	bool b = false;

	do
	{
		Console.Write("{0}.) {1} ", i + 1, d2.ElementAt(i).Question);

		string? line = Console.ReadLine();

		if (string.IsNullOrEmpty(line) == false && (line.ToUpper() == "I" || line.ToUpper() == "H"))
		{
			b = true;
			Console.Clear();
			guesses.Add((line.ToUpper() == "I") ? true : false);
		}

	} while (b != true);
}

double correct = 0;

for (int i = 0; i < d2.Count; ++i)
{
	if (d2.ElementAt(i).Answer == guesses.ElementAt(i))
	{
		Console.WriteLine("{0}.) -", i + 1);
		++correct;
	}
	else
	{
		Console.WriteLine("{0}.) -> [{1} Tipp: {2} Helyes: {3}]", i + 1, d2.ElementAt(i).Question, Data.SFordito(guesses.ElementAt(i)), d2.ElementAt(i).Fordito());
	}
}

Console.WriteLine("Összesen: {0}/{1} {2:0.00}%", correct, d2.Count, correct / d2.Count * 100);

class Data
{
	public string Question = null!;
	public bool Answer;

	public string Fordito()
	{
		if (Answer == true)
		{
			return "Igaz";
		}

		return "Hamis";
	}

	public static string SFordito(bool Answer)
	{
		if (Answer == true)
		{
			return "Igaz";
		}

		return "Hamis";
	}
}