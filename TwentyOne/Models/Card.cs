﻿using System.Drawing;

namespace TwentyOne.Models
{
    public class Card
    {
        public const int MaxSuitNumber = 4;
        public const int MaxCardNumber = 13;
        public const int CardBackNumber = 14;

        public int UniqueID { get; set; }
        public bool IsVisible { get; set; }
        public int SuitNumber { get; set; }
        public enum SuitType { Hearts, Spades, Diamonds, Clubs }
        public int CardNumber { get; set; }
        public enum CardType { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        public int PointValue
        {
            get
            {
                switch (CardNumber)
                {
                    case (int)CardType.Jack:
                    case (int)CardType.Queen:
                    case (int)CardType.King:
                        return 10;
                    default:
                        return CardNumber;
                }
            }
        }

        public Card()
        {
            //TODO:  pull from card stack to avoid getting dup cards, etc.
            UniqueID = Random.Shared.Next(1, int.MaxValue);
            CardNumber = Random.Shared.Next(1, MaxCardNumber);
            SuitNumber = Random.Shared.Next(1, MaxSuitNumber);
            IsVisible = true;
        }

        public byte[] GetImageData
        {
            get
            {
                return GetImage(SuitNumber, CardNumber);
            }
        }

        public byte[] GetImageDataForBackOfCard
        {
            get
            {
                return GetImage(SuitNumber, CardBackNumber);
            }
        }

        private byte[] GetImage(int suitNumber, int cardNumber)
        {
            try
            {
                // Create a Bitmap object from a file.
                Bitmap bitmap = new(@".\Images\card-set-1.jpg");

                int leftMargin = 1;
                int topMargin = 10;
                int cardWidth = 114;
                int cardHeight = 167;

                // Clone a portion of the Bitmap object.
                Rectangle cloneRect = new Rectangle(leftMargin + (cardNumber - 1) * cardWidth, (suitNumber - 1) * cardHeight, cardWidth, cardHeight);
                Bitmap cloneBitmap = bitmap.Clone(rect: cloneRect, bitmap.PixelFormat);

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
