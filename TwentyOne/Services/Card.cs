using System.Drawing;

namespace TwentyOne.Services
{
    public class Card
    {
        public const int MaxSuitNumber = 4;
        public const int MaxCardNumber = 13;

        public bool IsVisible { get; set; }
        public int SuitNumber { get; set; }
        public int CardNumber { get; set; }

        public Card()
        {
            //TODO:  pull from card stack to avoid getting dup cards, etc.
            CardNumber = Random.Shared.Next(1, Card.MaxCardNumber);
            SuitNumber = Random.Shared.Next(1, Card.MaxSuitNumber);
            IsVisible = true;
        }

        public byte[] ImageBytes
        {
            get
            {
                return GetImage(SuitNumber, CardNumber);
            }
        }

        private byte[] GetImage(int suitNumber, int cardNumber)
        {
            try
            {
                // Create a Bitmap object from a file.
                Bitmap myBitmap = new(@".\Images\card-set-1.jpg");

                int leftMargin = 1;
                int topMargin = 10;
                int cardWidth = 114;
                int cardHeight = 167;

                // Clone a portion of the Bitmap object.
                Rectangle cloneRect = new Rectangle((leftMargin) + ((cardNumber - 1) * cardWidth), ((suitNumber - 1) * cardHeight), cardWidth, cardHeight);
                Bitmap cloneBitmap = myBitmap.Clone(cloneRect, myBitmap.PixelFormat);

                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(cloneBitmap, typeof(byte[]));
            }
            catch (Exception ex)
            {
                //TODO:  error logging
                throw;
            }
        }
    }
}
