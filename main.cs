using System;
using System.IO;
using System.Collections.Generic;

class Usuario{
  protected int cpf;
  protected string nome;
  protected string email;
  protected string senha;
  protected int idade;

  public Usuario(int cpf_user,string nome_user, string email_user, string senha_user,int idade_user){
    cpf = cpf_user;
    nome = nome_user;
    email = email_user;
    senha = senha_user;
    idade = idade_user;
  }

  public Usuario(){

  }

  public void setCpf(int cpf_us){
    cpf = cpf_us;
  }

  public void setNome(string nome_us){
    nome = nome_us;
  }

  public void setEmail(string email_us){
    email = email_us;
  }

  public void setSenha(string senha_us){
    senha = senha_us;
  }

  public void setidade(int idade_us){
    idade = idade_us;
  }

  public string getNome(){
    return nome;
  }

  public int getIdade(){
    return idade;
  }
}

class Paciente:Usuario {
  protected string[] sintomas;
  protected string[] doencas;

  
  public Paciente(string[] sint_paciente,string[] doenc_paciente, int cpf,string nome, string email, string senha, int idade ): base(cpf, nome, email,senha,idade) {
    int tam1 = sint_paciente.Length;
    sintomas = new string[tam1];
    for(int i=0;i<tam1;i++){
      sintomas[i] = sint_paciente[i];
    }

    int tam2 = doenc_paciente.Length;
    doencas = new string[tam2];
    for(int j=0;j<tam2;j++){
      sintomas[j] = doenc_paciente[j];
    }
  }

  public Paciente(){

  }

  public string getSintoma(int index){
    return sintomas[index];
  }




}

class Doença{
  protected string código;
  protected string nome;
  protected string[] sintomas;
  
  public Doença(string cod, string nm,string nomeArquivo){
    código = cod;
    nome = nm;
    
    if (File.Exists(nomeArquivo+".txt")) {
      List<string> listaSintomas = new List<string>();
      using(StreamReader file = new StreamReader(nomeArquivo+".txt")) {  
        
        string linha;  
          
        while ((linha = file.ReadLine()) != null) { 
          listaSintomas.Add(linha);
        }  
        file.Close();  
      }
      sintomas =  listaSintomas.ToArray();
   }
    
  }

  public string getSintomas(int index){
    return sintomas[index];
  }
}

class MainClass {
  public static void Main (string[] args) {

    //REGISTRO DE DOENÇAS E SINTOMAS 
    
    
    //CADASTRO PACIENTE
    Paciente paciente = new Paciente();
    paciente = CadastrarPaciente();   
    
    }

  public static Paciente CadastrarPaciente(){
    int cpf_cadastro;
    string nome_cadastro;
    string email_cadastro;
    string senha_cadastro;
    int idade_cadastro;

    Console.WriteLine("\nCADASTRO DE PACIENTE");
    Console.WriteLine("Digite seu CPF: ");
    cpf_cadastro = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Digite seu nome completo:");
    nome_cadastro = Console.ReadLine();
    Console.WriteLine("Digite sua senha:");
    senha_cadastro = Console.ReadLine();
    Console.WriteLine("Digite seu e-mail:");
    email_cadastro = Console.ReadLine();
    Console.WriteLine("Digite sua idade:");
    idade_cadastro = Convert.ToInt32(Console.ReadLine());

    //CHECAGEM DE SINTOMAS DO PACIENTE

    Console.WriteLine("\nCHECAGEM DE SINTOMAS");

    // Leitura de sintomas
    List<string> listaSintomas = new List<string>();
    listaSintomas = Leitura("listadesintomas","sintoma");
    string[] sintomas_paciente = listaSintomas.ToArray();

    Console.WriteLine("\n\nCHECAGEM DE DOENÇAS");

     //INICIO Leitura de doenças
    List<string> listaDoencas  = new List<string>();
    listaDoencas = Leitura("listadedoencas","doença");
    string[] doencas_paciente = listaDoencas.ToArray();

    //Criação do paciente
    Paciente paciente1 = new Paciente(sintomas_paciente,doencas_paciente,cpf_cadastro,nome_cadastro,email_cadastro,senha_cadastro,idade_cadastro);

    return paciente1;
  }
  
  public static List<string> Leitura(string nomedoarquivo, string tipoLista){
      List<string> lista = new List<string>();
      if (File.Exists(nomedoarquivo+".txt")) {
        using(StreamReader file = new StreamReader(nomedoarquivo+".txt")) {  
          string linha;  
                
          while ((linha = file.ReadLine()) != null) { 
            Console.WriteLine("\nVocê possui "+tipoLista+" do tipo: "+linha+"(s ou n)?");
            if(Console.ReadKey().KeyChar == 's'){
              lista.Add(linha);
            }
          }
          file.Close();  
        }
        
      }
      return lista;
    }
}