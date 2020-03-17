using System;
using System.Text;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {

            if (message == null)
            {
                throw new ArgumentNullException();
            }

            else
            {
                message = message.ToLower();
                StringBuilder numberList = new StringBuilder();

                for (int i = 0; i < message.Length; i++)
                {
                    if (((int)message[i] >= 48 && (int)message[i] <= 57) || (int)message[i] == 32) //é um número ou espaço 
                    {
                        numberList.Append(message[i]);
                    }

                    else if ((int)message[i] >= 97 && (int)message[i] <= 122) //é uma letra
                    {
                        if ((int)message[i] == 120) // case x
                        {
                            int code = (int)message[i] - 23;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);

                        }
                        else if ((int)message[i] == 121) // case y
                        {
                            int code = (int)message[i] - 23;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);
                        }
                        else if ((int)message[i] == 122) // case z
                        {
                            int code = (int)message[i] - 23;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);
                        }
                        else 
                        {
                            int code = (int)message[i] + 3;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);
                        }
                    }

                    else // é um caracter especial
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                }

                return numberList.ToString();
            }
        
        }

        public string Decrypt(string cryptedMessage)
        {

            if (cryptedMessage == null)
            {
                throw new ArgumentNullException();
            }

            else
            {
                cryptedMessage = cryptedMessage.ToLower();
                StringBuilder numberList = new StringBuilder();

                for (int i = 0; i < cryptedMessage.Length; i++)
                {
                    if (((int)cryptedMessage[i] >= 48 && (int)cryptedMessage[i] <= 57) || (int)cryptedMessage[i] == 32) //é um número ou espaço 
                    {
                        numberList.Append(cryptedMessage[i]);
                    }

                    else if ((int)cryptedMessage[i] >= 97 && (int)cryptedMessage[i] <= 122) //é uma letra
                    {
                        if ((int)cryptedMessage[i] == 97) // case a
                        {
                            int code = (int)cryptedMessage[i] + 23;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);
                        }
                        else if ((int)cryptedMessage[i] == 98) // case b
                        {
                            int code = (int)cryptedMessage[i] + 23;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);
                        }
                        else if ((int)cryptedMessage[i] == 99) // case c
                        {
                            int code = (int)cryptedMessage[i] + 23;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);
                        }
                        else
                        {
                            int code = (int)cryptedMessage[i] - 3;
                            string aux = Char.ConvertFromUtf32(code);
                            numberList.Append(aux);
                        }
                    }

                    else // é um caracter especial
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                }
                return numberList.ToString();
            }
        }

        public static void Main()
        {
            //string message = "";
            //message = message.ToLower();
            //StringBuilder numberList = new StringBuilder();


            //if (message == null)
            //{
            //    throw new ArgumentNullException();
            //}

            //else
            //{
            //    for (int i = 0; i < message.Length; i++)
            //    {
            //        if (((int)message[i] >= 48 && (int)message[i] <= 57) || (int)message[i] == 32) //é um número ou espaço 
            //        {
            //            numberList.Append(message[i]);
            //        }

            //        else if ((int)message[i] >= 97 && (int)message[i] <= 122) //é uma letra
            //        {
            //            int code = (int)message[i] + 3;
            //            string aux = Char.ConvertFromUtf32(code);
            //            numberList.Append(aux);
            //        }

            //        else // é um caracter especial
            //        {
            //            throw new ArgumentOutOfRangeException();
            //        }

            //    }
            //    Console.WriteLine(numberList);

            //}

        }
    }

    
}
