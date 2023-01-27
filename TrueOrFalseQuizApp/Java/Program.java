import java.io.*;
import java.util.*;

class Data
{
	String question;
	boolean answer;

	public Data()
	{
	}

	public void Print()
	{
		System.out.println(question + " " + Translate());
	}

	public String Translate()
	{
		return (answer == true) ? "Igaz" : "Hamis";
	}

	public void Question()
	{
		System.out.print(question + " ");
	}

	public String QuestionValue()
	{
		return question;
	}
}

class Program
{
	public final static String Translate(boolean b)
	{
		return (b == true) ? "Igaz" : "Hamis";
	}

	public final static void ClearConsole()
	{
        System.out.print("\033[H\033[2J");  
		System.out.flush();
	}

	public static void main(String[] args) throws FileNotFoundException, IOException
	{
		var fr = new FileReader("data.txt");
		var br = new BufferedReader(fr);
		List<Data> dat = new ArrayList<>();
		String line = "";

		do
		{
			line = br.readLine();

			if(line != null && line.isEmpty() == false)
			{
				String question = "";
				String answer = "";
				dat.add(new Data());		
				dat.get(dat.size() - 1).question = line.substring(0, line.indexOf(";"));
				dat.get(dat.size() - 1).answer = (line.charAt(line.length() - 1) == 'I') ? true : false;
			}

		} while(line != null);

		br.close();
		fr.close();

		Collections.shuffle(dat);
		var sc = new Scanner(System.in);
		List<Boolean> guesses = new ArrayList<>();
		ClearConsole();

		for(var v : dat)
		{
			v.Question(); 
			line = sc.nextLine();
			guesses.add(line.toUpperCase().equals("I") ? true : false);
			ClearConsole();
		}

		for(int i = 0; i < dat.size(); ++i)
		{
			if(dat.get(i).answer == guesses.get(i))
			{
				System.out.println(i + 1 + ".) -");
			}
			else
			{
				System.out.print(i + 1 + ".) "); dat.get(i).Question(); System.out.println("Your guess: " + Translate(guesses.get(i)) + ", Actual: " + dat.get(i).Translate());
			}
		}
	}
}