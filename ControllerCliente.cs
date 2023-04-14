using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico
{
    public static class ControllerCliente
    {
        static Queue<Cliente> FilaCliente = new Queue<Cliente>(); //Cria uma fila do tipo Cliente
        static Boolean checador_Senha = true; // Criamos uma variável booleana que vamos usar mais a frente para auxiliar na validação da senha

        public static void InserirCliente() //Método que permite inserir cliente na lista
        {
            Console.WriteLine("\nDigite seu nome: "); // Pede dados ao usuário
            string nome = Console.ReadLine(); // Le esses dados
            Console.WriteLine("Digite seu sobrenome: ");
            string sobrenome = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if (ChecarSenha(senha) == false) // irá chamar o método que irá auxiliar a checagem das 2 regras da senha, caso retorne false será executado
            {

                Console.WriteLine("Senha indisponível, tente outra senha"); 
                ValidarChecarSenha(); // Chamamos esse método para validar a senha e poder executar o InserirCliente novamente
                
               
            }

            else //Caso a senha digitado tenha sido validado, o programa entra aqui para continuar a inserção do cliente na fila
            {
                int senha_numero = Int32.Parse(senha); //Converto o valor para inteiro, visto que meu construtor precisa receber um inteiro

                Console.WriteLine("Olá, seja bem-vindo " + nome + " " + sobrenome); 
                FilaCliente.Enqueue(new Cliente(nome, sobrenome, senha_numero)); //Crio um objeto do tipo cliente com os parâmetros digitados e insiro ele na fila
            }
        }


        static Boolean ChecarSenha(string senha) //Método para checar se a senha digitada cumpre os requisitos
        {
            Boolean checadorSenhaNaoIgual = true; // Variável booleana para auxiliar na validação da senha

            if (!senha.All(char.IsDigit))  //Como a senha precisa ser um dígito, esse método verifica se o parâmetro da senha recebido não é um número, se for o caso ele irá entrar nessa condicional
            {

                checador_Senha = false; //Se isso ocorre, nossa variável booleana agora recebe o valor de falso
                
            }
            else
            {
              checador_Senha = true; //Se não ocorre o if acima, a variável tem-se o valor de true
            }
            if(checador_Senha == true) //Se a variavel tem o valor de true, ou seja ele é sim um dígito, analisamos a condição de não poder já ter um cliente com a mesma senha
            {
              
                int senha_temporaria = Int32.Parse(senha); //Converto o parâmetro recebido em inteiro, pois precisarei comparar ele com um inteiro
                foreach (Cliente FilaTemporaria in FilaCliente) // o foreach vai passar por toda a fila
                {
                    if (FilaTemporaria.getSenha().Equals(senha_temporaria)) //Quando ele passar por ela, ele irá comparar o atributo senha de cada cliente dessa fila com a senha recebida, para caso sejam equivalentes
                    {
                        checador_Senha = false; //se for esse o caso, nossa variável auxiliadora recebe como valor false
                        checadorSenhaNaoIgual = false; // se houver uma senha com esse mesmo número essa variável recebe o valor false

                    }
                    
                }
                   if(checadorSenhaNaoIgual == true){ //Após sair do foreach, se esse variável mantiver o valor true, significa que não houve nenhum caso em que as senhas seriam iguais
                      checador_Senha = true; // Assim, nossa variável auxiliadora recebe o valor true
                    }
                }
            
            return checador_Senha; //Como é um método booleano, ele retorna esse tipo, que é o que será analisado na função que a chamou

        }

        public static void ValidarChecarSenha(){ //Esse método será chamado somente se a sennha digitado pelo usuário não cumprir uma das regras
         
                InserirCliente(); //Assim, ele terá que começar do passo 1 novamente
            
        }

        public static void LimparFila() 
        {
            FilaCliente.Clear(); //Método próprio da fila para limpar ela
        }

        public static void ImprimirElementos() // Retornar todos os elementos da fila e seus atributos
        {
            Console.WriteLine("\nElementos da fila: ");
            foreach (Cliente cli in FilaCliente) // O foreach percorre toda a fila
            {
                Console.Write("\n " + cli.getNome() + " " + cli.getSobrenome() + " | " + cli.getSenha() + "\n"); // e retornar os atributos de cada um deles
            }
        }
      
        public static void RemoverCliente(int senha) //Método para remover cliente
        {

            
            Boolean verificador = false; // Variável para auxiliar no condicional
            foreach (Cliente client in FilaCliente) //Percorremos a fila
            {
                if (client.getSenha().Equals(senha)) // Procuramos um cliente que possuam o atributo senha igual ao número digitado pelo usuário
                {

                
                    FilaCliente = new Queue<Cliente>(FilaCliente.Where(x => x != client)); //Aqui utilizado um método do c# em que a fila ela terá todos os outros elementos, os quais não sejam igual ao objeto cliente acima(aquele que possui a senha correspondente), assim esse elemento não é mais parte da fila
                    verificador = true; //Se isso ocorre, colocamos essa variável auxiliadora como true
              
                    Console.WriteLine("O cliente " + client.getNome() + " com a senha " + client.getSenha() + " foi removido"); //Retornamos mensagem para informar da remoção do cliente da fila

                }

            }
            if (!verificador) //Usamos essa variável, pois caso depois de passar pelo foreach não seja encontrado uma senha igual, o verificador ainda terá valor false e entrará nese condicionaç
            {
                Console.WriteLine("Não reconhecemos essa senha, por favor faça o cadastro dela: "); //Retornamos a mensagem informando que essa senha não existe 
                InserirCliente(); //Voltamos ao passo 1 para o usuário inserir um cliente na fila novamente
            }
        }


    }

}
