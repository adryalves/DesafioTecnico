// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico
{
    public class Cliente
    {
        private string nome;
        private string sobrenome;
        private int senha;

        public Cliente(string nome, string sobrenome, int senha){
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.senha = senha;
        }

        public string getNome(){
            return nome;
        }
        public void setNome(string nome){
            this.nome = nome;
        }

    
    public string getSobrenome() {
        return sobrenome;
    }


    public void setSobrenome(string sobrenome) {
        this.sobrenome = sobrenome;
    }


    public int getSenha() {
        return senha;
    }

   
    public void setSenha(int senha) {
        this.senha = senha;
    }


    public string Imprimir(){
        return "Nome: " + getNome() + " Sobrenome" + this.getSobrenome() + " senha: " + this.getSenha();
    }

}
}
