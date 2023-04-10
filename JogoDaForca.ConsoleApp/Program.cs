using System;
using System.Collections;
namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static ArrayList palavras = new ArrayList();
        static string palavraProJogo = "";
        static int erros = 0;
        static char[] letrasDaPalavra, palavrasNaForca;
        static bool letraExiste;
        static char letraChutadaPeloUsuario;
        static int tentativas = 5;


        static void Main(string[] args)
        {
            AdicionaFrutasNaLista();
            GeraPalavraAleatoria();
            TransformarStringEmChar();
            ColocaValoresNosArrays();
            RodaOjogo();
            MostraResultadoAoUsuario();

        }

        private static void RodaOjogo()
        {
            while (palavrasNaForca.Contains('_') && tentativas != 0)
            {
                PegaDigitoDoUsuario();
                VerificaSeDigitoExiste();
            }
        }

        private static void MostraResultadoAoUsuario()
        {
            Console.Clear();

            if (tentativas == 0)
            {
                Console.WriteLine("______________________");
                Console.WriteLine("Você Perdeu....F ");
                Console.WriteLine("A palavra era " + palavraProJogo);
                Console.WriteLine("______________________");
            }
            else
            {
                Console.WriteLine("______________________");
                Console.WriteLine("Você venceu");
                Console.WriteLine("Restando " + tentativas + " Tentativas");
                Console.WriteLine("______________________");
            }
        }

        private static void VerificaSeDigitoExiste()
        {
            if (letraExiste == false)
            {

                for (int i = 0; i < palavraProJogo.Length; i++)
                {

                    if (letraChutadaPeloUsuario == palavrasNaForca[i])
                    {

                        MensagemDeErro("\nLetra já digitada -- Aperte Enter");
                        letraExiste = true;
                    }
                    else if (letraChutadaPeloUsuario == letrasDaPalavra[i])
                    {
                        palavrasNaForca[i] = letraChutadaPeloUsuario;
                        letraExiste = true;
                    }

                }
                Console.Clear();
            }
            if (letraExiste == false)
            {
                tentativas--;
                erros++;
                MensagemDeErro("Você Errou...");
            }
        }

        private static void MensagemDeErro(string mensagem)
        {
            Console.WriteLine("______________________");
            Console.WriteLine(mensagem);
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.WriteLine("______________________");
            Console.ReadKey();

        }

        private static void PegaDigitoDoUsuario()
        {
            letraExiste = false;
            DesenhaForca();
            Console.Write("\nQual seu Chute?: ");
            letraChutadaPeloUsuario = Convert.ToChar(Console.ReadLine().ToUpper());
        }

        private static void DesenhaForca()
        {
            if (erros == 0)
            {
                Console.Write(" ________\n" +
                                 "|/       |\n" +
                                 "|        |\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n\n");
            }
            if (erros == 1)
            {
                Console.Write(" ________\n" +
                                 "|/       |\n" +
                                 "|        |\n" +
                                 "|   " + "     o\n" +
                                 "|   " + "    \n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|______\n\n");
            }
            if (erros == 2)
            {
                Console.Write(" ________\n" +
                                 "|/       |\n" +
                                 "|        |\n" +
                                 "|   " + "     o\n" +
                                 "|   " + "    | \n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|______\n\n");
            }
            if (erros == 3)
            {
                Console.Write(" ________\n" +
                                 "|/       |\n" +
                                 "|        |\n" +
                                 "|   " + "     o\n" +
                                 "|   " + "    | |\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|______\n\n");
            }
            if (erros == 4)
            {
                Console.Write(" ________\n" +
                                 "|/       |\n" +
                                 "|        |\n" +
                                 "|   " + "     o\n" +
                                 "|   " + "    |X|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|______\n\n");
            }
            if (erros == 5)
            {
                Console.Write(" ________\n" +
                                 "|/       |\n" +
                                 "|        |\n" +
                                 "|   " + "     o\n" +
                                 "|   " + "    |X|\n" +
                                 "|   " + "     X\n" +
                                 "|\n" +
                                 "|\n" +
                                 "|______\n\n");
            }
            for (int i = 0; i < palavraProJogo.Length; i++)
            {
                Console.Write(palavrasNaForca[i] + " ");
            }
            Console.WriteLine();
        }

        private static void ColocaValoresNosArrays()
        {
            for (int i = 0; i < palavraProJogo.Length; i++)
            {
                if (letrasDaPalavra[i] == ' ')
                {
                    palavrasNaForca[i] = ' ';
                }
                else
                {
                    palavrasNaForca[i] = '_';
                }
            }
            Console.Clear();
        }

        private static void TransformarStringEmChar()
        {
            letrasDaPalavra = palavraProJogo.ToCharArray();
            palavrasNaForca = palavraProJogo.ToCharArray();
            char[] digitados = palavraProJogo.ToCharArray();
        }

        static string GeraPalavraAleatoria()
        {
            Random aleatoria = new();
            int palavraAleatoria = aleatoria.Next(0, 29);

            for (int i = 0; i < palavras.Count; i++)
            {
                if (i == palavraAleatoria)
                {
                    palavraProJogo = palavras[i].ToString();
                }
            }
            return palavraProJogo;
        }

        private static void AdicionaFrutasNaLista()
        {
            palavras.Add("UVAIA");
            palavras.Add("UVA");
            palavras.Add("UMBU");
            palavras.Add("TANGERINA");
            palavras.Add("SAPOTI");
            palavras.Add("PITANGA");
            palavras.Add("PEQUI");
            palavras.Add("MURICI");
            palavras.Add("MARACUJA");
            palavras.Add("MANGA");
            palavras.Add("MANGABA");
            palavras.Add("MACA");
            palavras.Add("JENIPAPO");
            palavras.Add("GOIABA");
            palavras.Add("JABUTICABA");
            palavras.Add("GRAVIOLA");
            palavras.Add("CUPUACU");
            palavras.Add("CARAMBOLA");
            palavras.Add("CAJU");
            palavras.Add("CAJA");
            palavras.Add("BANANA");
            palavras.Add("BACURI");
            palavras.Add("BACABA");
            palavras.Add("ARACA");
            palavras.Add("ACAI");
            palavras.Add("ACEROLA");
            palavras.Add("ABACAXI");
            palavras.Add("ABACATE");
        }
    }
}
