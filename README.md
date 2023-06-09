
# True or False Quiz Application
This console application is designed to help you prepare for exams that require quick responses to true or false questions. The application operates based on an input file that contains the questions and their corresponding answers. Please note: The application is provided in Hungarian, but it can be used by anyone as it primarily relies on a simple input format.

## Getting started
1. Ensure you have the necessary input file in the project directory. The file should follow a specific syntax (explained below) to provide the quiz questions and answers.
2. Run the application, and the quiz will be displayed, presenting all the questions along with their corresponding answers in alphabetical order.
3. Press any key to start the actual quiz. Each question will be presented individually in a randomized order, and you will need to respond with `i` for True or `h` for False.
4. At the end of the quiz, your results will be displayed, indicating the number of correct and incorrect answers.

## Input file syntax
The `input.txt` file follows a specific syntax for defining the quiz questions and answers. Each line represents a single question, and the format of each line should be as follows:
```
{question};{answer}
```
* {question}: Represents the true or false question.
* ; (semicolon): Serves as the separator between the question and the answer.
* {answer}: Either a capital `I` for True, or a capital `H` for False.

Here is an example that demonstrates a 3-question input file:

```
The sky is blue.;I
Cats are reptiles.;H
Water boils at 100 degrees Celsius.;I
```
