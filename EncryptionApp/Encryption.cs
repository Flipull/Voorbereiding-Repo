using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionApp
{
    class Encryption
    {
        private static int ENCRYPT_ROUNDS = 16;

        //PREVIOUS_BYTE_LENGTH smeert meerdere bits uit (Hash-achtig gedrag, kleine wijzigingen in de text hebben een grote invloed op de ge-encrypte text
        private static int PREVIOUS_BYTE_LENGTH = 8;

        public Encryption()
        {
            
        }

        public byte[] XorEncrypt(byte[] data, byte[] password)
        {
            //validate password-length
            //validate data -length

            //create copy of data
            byte[] encryptable_data = new byte[data.Length];
            data.CopyTo(encryptable_data, 0);

            //loop rounds
            for (uint round_loop = 0; round_loop < ENCRYPT_ROUNDS; round_loop++)
            {
                //loop data
                for (uint data_loop = 0; data_loop < encryptable_data.Length; data_loop++)
                {
                    int current_bytenumber = (int)(round_loop * encryptable_data.Length + data_loop);
                    byte current_encrypted_byte = encryptable_data[current_bytenumber % encryptable_data.Length];

                    //loop previous-data-loop
                    for (uint prev_data_loop = 1; prev_data_loop <= PREVIOUS_BYTE_LENGTH; prev_data_loop++)
                    {
                        //current databyte = previous data-bytes and XOR them
                        int prev_byte_number = (int)((current_bytenumber - prev_data_loop) % encryptable_data.Length);  //strange feature: % (modulus) van negatief getal is een negatief resulaat
                        if (prev_byte_number < 0) prev_byte_number += encryptable_data.Length;                          //strange feature fix

                        current_encrypted_byte = (byte)(current_encrypted_byte ^ encryptable_data[prev_byte_number]);

                       
                    }
                    //current databyte XOR password-byte
                    current_encrypted_byte = (byte)(current_encrypted_byte ^ password[current_bytenumber % password.Length]);

                    encryptable_data[current_bytenumber % encryptable_data.Length] = current_encrypted_byte;

                }
            }
            return encryptable_data;
        }


        public byte[] XorDecrypt(byte[] data, byte[] password)
        {
            //validate password-length
            //validate data -length

            //create copy of data
            byte[] decryptable_data = new byte[data.Length];
            data.CopyTo(decryptable_data, 0);

            
            //loop rounds
            for (int round_loop = ENCRYPT_ROUNDS-1; round_loop >= 0; round_loop--)
            {
                //loop data
                for (int data_loop = (int)decryptable_data.Length-1; data_loop >= 0; data_loop--)
                {
                    int current_bytenumber = (int) (round_loop * decryptable_data.Length + data_loop);
                    byte current_encrypted_byte = decryptable_data[current_bytenumber % decryptable_data.Length];

                    //loop previous-data-loop
                    for (int prev_data_loop = PREVIOUS_BYTE_LENGTH; prev_data_loop >= 1; prev_data_loop--)
                    {
                        //current databyte = previous data-bytes and XOR them
                        int prev_byte_number = (int)((current_bytenumber - prev_data_loop) % decryptable_data.Length);  //strange feature: % (modulus) van negatief getal is een negatief resulaat
                        if (prev_byte_number < 0) prev_byte_number += decryptable_data.Length;                          //strange feature fix

                        current_encrypted_byte = (byte)(current_encrypted_byte ^ decryptable_data[prev_byte_number]);
                    }
                    //current databyte XOR password-byte
                    current_encrypted_byte = (byte)(current_encrypted_byte ^ password[current_bytenumber % password.Length]);
                    
                    decryptable_data[current_bytenumber % decryptable_data.Length] = current_encrypted_byte;
                    
                }
            }
            return decryptable_data;
        }

    }
}
