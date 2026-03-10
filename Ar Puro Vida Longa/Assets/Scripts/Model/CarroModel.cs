// Model/CarroModel.cs
[System.Serializable]
public class CarroModel
{
    public string nome;
    public int pontos;
    public bool catalisadorAplicado;

    public CarroModel(string nome, int pontos)
    {
        this.nome = nome;
        this.pontos = pontos;
        this.catalisadorAplicado = false;
    }

    public void AplicarCatalisador()
    {
        catalisadorAplicado = true;
    }
}