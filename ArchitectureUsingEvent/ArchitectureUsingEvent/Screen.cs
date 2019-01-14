using System;

namespace ArchitectureUsingEvent
{
    public class Screen : IScreen
    {
        public string Answer { get; set; }
        public string Warning { get; set; }
        public string TextValue { get; set; }
        public string TextLength { get; set; }

        private readonly string _exitString = "q";
        public Worker MyWorker { get; set; }

        public Screen(IMessage message, MLength mLength)
        {
            TextValue = message.MyMessage;
            Warning = "Nothing to warn about";
            TextLength = mLength.MessageLength;
            //Screen needs to add its MessageSetEventHandler method
            //to the event in message

            MyWorker = new Worker(this, message, mLength);

            mLength.MessageSetLengthEvent += MessageSetLengthEventHandler;
            message.MessageSetEvent += MessageSetEventHandler;

        }

        private void MessageSetLengthEventHandler(object sender, CustomArgs customArgs)
        {
            TextLength = customArgs.MessageAfter;
        }

        void MessageSetEventHandler (object sender, CustomArgs customArgs)
        {
			//sender is not used as all information needed is in customArgs
			
			TextValue = customArgs.MessageAfter;
            Warning = $"Text changed from: \"{customArgs.MessageBefore}\" and new text length is {TextLength}";
        }

        public void ShowScreen()
        {
            bool stop = false;
            do
            {
                Console.Clear();
                Console.WriteLine("*************************************");
                Console.WriteLine($"Warning : {Warning}");
                Console.WriteLine($"Text : {TextValue}\n");
                Console.WriteLine("*************************************\n");
                Console.WriteLine($"Enter \"{_exitString}\" to exit program");
                Console.WriteLine($"Enter \"r\" to reverse \"Text\"");
                Console.WriteLine($"Any other text changes \"Text\"\n");
                Console.Write("Enter choice: ");
                Answer = Console.ReadLine();
                if (Answer != null && Answer.ToUpper().Equals("R"))
                {
                    MyWorker.ReverseTextValue();
                }
                else
                {
                    //The Message.MyMessage should change to the text in Answer
                    MyWorker.SetTextValue();
                }

                if (Answer != null) stop = Answer.ToUpper().Equals(_exitString.ToUpper());
            } while (stop == false);
        }
    }
}
