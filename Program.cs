using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaEoMonstroComBooleanas
{
    class Program
    {
        static void Main(string[] args)
        {
            // VARIÁVEIS ---------------------

            // controle
            string resposta = "";
            // Porta    true - aberta       false - fechada
            bool porta = false;
            // Tranca   true - trancado     false - destrancado
            bool tranca = true;
            // Posição  true - dentro       false - fora
            bool posicao = true;

            // Monstro true - esta ai       false - não esta
            bool monstro = false;

            // Variavel para chances e aleaóriedades aleatórias
            Random rnd = new Random();
            // chance de aparecer um monstro
            int porcentagemDeSpawn = 10;
            // chance de sobreviver com a porta encostada
            int porcentagemDeSobreviverAPortasFechadas = 70;
            // turno que aguenta sem sair de casa
            int fomeMaxima = 10;
            int fome = 11;

            //Contador de turnos
            int contador = 0;

            //--------------------------------

            do
            {
                contador = contador + 1;

                if (posicao)
                {
                    fome = fome - 1;
                    if (fome <= 0)
                    {
                        Console.WriteLine("VOCÊ MORREU DE FOME!");
                        Console.WriteLine("GAME OVER");
                        resposta = "0";
                    }
                }
                else if (!monstro)
                {
                    Console.WriteLine("VOCÊ SE ALIMENTOU!");
                    fome = fomeMaxima;
                }

                Console.ReadLine();
                // limpa a tela 
                Console.Clear();
                // operação
                Console.WriteLine("-------------------------");
                Console.WriteLine("- 1 - Abrir porta       -");
                Console.WriteLine("- 2 - Fechar porta      -");
                Console.WriteLine("- 3 - Chavear porta     -");
                Console.WriteLine("- 4 - Deschavear porta  -");
                Console.WriteLine("- 5 - Sair pela porta   -");
                Console.WriteLine("- 6 - Entrar pela porta -");
                Console.WriteLine("- 7 - Passar a vez      -");
                Console.WriteLine("- 0 - Fechar Jogo       -");
                Console.WriteLine("-------------------------");

                //-----------------------------------

                Console.Write("TURNO:[" + contador + "] FOME:[" + fome + "] ");

                //-----------------------------------

                if (porta)
                    Console.Write("PORTA:[ABERTA ]");
                else
                    Console.Write("PORTA:[FECHADA]");

                //-----------------------------------

                if (!porta)
                {
                    if (tranca)
                        Console.Write("[TRANCADA   ]");
                    else
                        Console.Write("[DESTRANCADA]");
                }
                Console.WriteLine("");
                //-----------------------------------

                if (posicao)
                    Console.Write(" Você esta [EM CASA     ]");
                else
                    Console.Write(" Você esta [FORA DE CASA]");

                //-----------------------------------

                if (monstro)
                    Console.WriteLine(" Monstro [ATACANDO   ]");
                else
                    Console.WriteLine(" Monstro [ESCONDIDO  ]");

                //-----------------------------------

                // controle
                Console.Write("Opção: ");
                resposta = Console.ReadLine();
                Console.WriteLine("-------------------------");

                // Opções do Menu
                //--------------------------------
                if (resposta == "1") // Abrir
                {
                    if (!tranca)
                        porta = true;
                }
                else if (resposta == "2")// Fechar
                {
                    tranca = false;
                    porta = false;
                }
                else if (resposta == "3")// Chavear
                {
                    tranca = true;
                }
                else if (resposta == "4")// Destrancar
                {
                    tranca = false;
                }
                else if ((resposta == "5") && (porta))// Sair
                {
                    posicao = false;
                }
                else if ((resposta == "6") && (porta))// Entrar
                {
                    posicao = true;
                }
                else if (resposta == "7")// Passar a vez
                {

                }
                else if (resposta == "0")// Finalizar o programa
                {

                }
                else
                {
                    Console.WriteLine("Sua opção é inválida");
                }
                //--------------------------------

                if (monstro)
                {
                    if ((!posicao) || (porta))
                    {
                        Console.WriteLine("O MONSTRO COMEU VOCÊ!");
                        Console.WriteLine("GAME OVER");
                        resposta = "0";
                    }
                    else if ((posicao) && (!tranca))
                    {
                        if (rnd.Next(1, 101) < porcentagemDeSobreviverAPortasFechadas)
                        {
                            Console.WriteLine("O MONSTRO ABRIU A PORTA E COMEU VOCÊ!");
                            Console.WriteLine("GAME OVER");
                            resposta = "0";
                        }
                        else
                        {
                            Console.WriteLine("O MONSTRO BATEU NA PORTA!");
                        }
                    }
                }

                //--------------------------------
                if (!monstro && ((!tranca) || ((tranca) && (!posicao))))
                {
                    // numero sorteado  deve ser menor ou igual ao valor do spawn
                    monstro = (rnd.Next(1, 101) <= porcentagemDeSpawn);
                }

                if (tranca)
                {
                    monstro = false;
                }
                //--------------------------------

                // validação
            } while (resposta != "0");

            Console.ReadLine();

        }
    }
}
