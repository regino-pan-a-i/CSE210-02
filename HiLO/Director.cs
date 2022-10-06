using System;
namespace CSE21002.HiLo{


public class Director{
    //Director's attributes

       Boolean IsPlaying = true;
        
        public string Guess = "";

        Score score = new Score();
        Deck deck = new Deck();


        public void Main(){
            //ininitialize classes and such
            Score score = new Score();
            Deck deck = new Deck();
            Play();
        }
    //start game loop
        public void Play(){
            
            //choice is condition and remains true until user types no
            // draw card
            // this while loop is the main loop and only stops when IsPlaying = False\

            while (IsPlaying == true)
            {
                //game loop
                Guess = getInputs();
                doUpdates();
                doOutputs();
            }

                }
        public string getInputs(){
            //while player continue answer y or score > 0
            
            Console.Write("The previous card was []");

            Console.Write("Would you like to enter another guess? Enter y or n > ");
            bool choice = true;
            IsPlaying = true; // if they want to keep playing
            while (choice){
               string play = Console.ReadLine();
            // this loop makes sure that the user guess is y or n and will re-do the l
                if (string.Equals(play, "y") && score.ScoreValue > 0){
                    choice = false;
                    IsPlaying = true;
                }
                else if (string.Equals(play, "n") || score.ScoreValue == 0){
                    choice = false;
                    IsPlaying = false;
                }
                else {
                    choice = true;                    
                    Console.WriteLine("Enter a valid input such as y or n");                
                    }            
                    }            
                    Console.Write("Will the next card be high or low?");    
                    bool loop = true;            
                    while (loop){                
                // this loop makes sure that the user guess is h or l and will re-do the loop if otherwise
                    string Guess = Console.ReadLine();

                if (string.Equals(Guess, "h")){
                    loop = false;
                }
                else if (string.Equals(Guess, "l") || score.ScoreValue == 0){
                    loop = false;
                }
                else {
                    loop = true;
                    Console.WriteLine("Enter a valid input such as h or l > ");
                }
            
            }
            return Guess;
            
        }
        public void doUpdates(){
        // takes in the values of the previous draw, the new draw, and the guess
            // it will use the methods further explained in score.csic void doUpdates(Guess){
            
            score.IsGuessCorrect(deck.PrevDraw, deck.num, Guess);
            score.UpdateScore();
            
        }
        public void doOutputs(){// prints the updated score
                        
            Console.WriteLine($"Your score is: {score.ScoreValue}");
            if (score.ScoreValue <= 0){
                Console.WriteLine("You've lost");
                IsPlaying = false;
            };
        }

        }

    }

