using Assent;
using System.Text;

namespace Kata.Tests.BugsZero
{
    public class TriviaTests
    {
        [Fact]
        public void RefactoringTests()
        {
            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));

            Game aGame = new Game();
            Console.WriteLine(aGame.IsPlayable());
            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);

            aGame.HandleCorrectAnswer();
            aGame.WrongAnswer();

            aGame.Roll(2);

            aGame.Roll(6);

            aGame.WrongAnswer();

            aGame.Roll(2);

            aGame.Roll(2);


            aGame.WrongAnswer();

            aGame.HandleCorrectAnswer();
            aGame.Roll(1);
            aGame.HandleCorrectAnswer();

            var configuration = BuildConfiguration();
            this.Assent(output.ToString(), configuration);
        }

        private static Configuration BuildConfiguration()
        {
            return
                new Configuration()

                // Uncomment this block if an exception 
                // « Could not find a diff program to use »
                // is thrown and if you have VsCode installed.
                // Otherwise, use other DiffProgram with its full path
                // as parameter.
                // See  https://github.com/droyad/Assent/wiki/Reporting
                //                    .UsingReporter(
                //                        new DiffReporter(
                //                            new []
                //                            {
                // For linux
                //                                new VsCodeDiffProgram(new []
                //                                {
                //                                    "/usr/bin/code"
                //                                })

                // For Windows
                //                                new VsCodeDiffProgram(), 
                //                            }))
                ;
        }
    }
}
