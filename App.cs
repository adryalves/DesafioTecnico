using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico
{
    public class App
    {

        public static String menu()  //A função menu que será chamada para exibir a tela de opções para o usuário
        {
            return "\nPressione Enter para inserir um novo cliente na fila\n" +
                   "Digite 'exit' para finalizar o console\n" +
                   "Digite 'limpar' para zerar a fila\n" +
                   "Digite 'ver' para visualizar a fila de clientes ordenada por número da\n" +
                   "matrícula\n" +
                   "Digite o número da senha para remover o Cliente da fila\n";
        }

        public static void Main(string[] args)
        {

//Poderia ser feito um switch, usar um uppercase no EXIT, reduzir as funções, menos ifs
            ControllerCliente.InserirCliente(); // O programa já necessita iniciar cadastrando o primeiro cliente da fila, a função é chamada no início

            Console.WriteLine(menu()); // Chama a função menu() e exibe para o cliente

            ConsoleKeyInfo tecla = Console.ReadKey(true); //Guarda se o usuário apertou alguma tecla
            string operacao = Console.ReadLine();  //ler o que foi digitado pelo usuario na variável operação
       
            while (operacao != "exit" && operacao != "Exit")  //Dentro desse laço de repetição será executado até que o usuario digite exit ou Exit, o que fará o programa encerrar
            {

                if (operacao.Equals("") && tecla.Key == ConsoleKey.Enter)  // Analisa se o usuário não digitou alguma palavra e se a tecla enter foi pressionada, se os dois ocorrerem ele entre nesse condicional
                {

                    ControllerCliente.InserirCliente(); //Como a tecla enter deseja que execute o passo 1, ele chama o método InserirCliente()

                }
                else  //Caso não tenha sido clicado o Enter, será analisado qual foi o valor da string digitada pelo usuário armazenada na variável operação
                {


                    if (operacao.Equals("limpar")) //Usamos o método próprio do C#, em que comparamos se o valor de operação equivale a string limpar
                    {

                        ControllerCliente.LimparFila(); //Se sim, chamamos o método para limpar a fila
                        Console.WriteLine("A fila foi esvaziada");
                    }

                    else if (operacao.Equals("ver")) //Caso tenha sido digitado "ver"
                    {
                        ControllerCliente.ImprimirElementos(); // Método que retorna todos os elementos da fila com seus correspondentes atributos
                      //  ControllerCliente.InserirCliente(); //O desafio pede que após imprimir os elementos, o usuário volte para o passo 1 de inserir cliente, eu considerei que ir para o menu seria a melhor opção, mas deixei essa opção comentada, pois ela possibilitaria voltar para o passo 1 depois da execução da de cima
                    }

                    else if (operacao.All(char.IsDigit)) //Utilizamos um método próprio do c# em que ele analisa se o valor armazenado na operação é um digito para que caso seja, faça a remoção do cliente que possua a senha igual a esse número digitado
                    {
                        int operacaosenha = Int32.Parse(operacao); //Caso seja, ele entra nessa linha de código e faz a conversão do valor que esta em operação para string
                        ControllerCliente.RemoverCliente(operacaosenha); //O método remover cliente é chamado passando como parametro o número digitado pelo usuário


                    }
                    else{ //Caso o usuário digite algo diferente que não é uma das opções, o programa retorna a ele uma mensagem de erro 
                        Console.WriteLine("Opção inválida, tente novamente"); 
                    }
                    

                }
                Console.WriteLine(menu()); //É exibido o menu novamente para que o usuário continue suas operações

                operacao = Console.ReadLine(); //Ler novamente a escolha do usuário

            }
            


        }

    }
}













