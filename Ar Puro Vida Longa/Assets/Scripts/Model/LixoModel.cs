// Model/LixoModel.cs
[System.Serializable]
public class LixoModel
{
    public string nome;
    public int pontos;
    public bool coletado;

    public LixoModel(string nome, int pontos)
    {
        this.nome = nome;
        this.pontos = pontos;
        this.coletado = false;
    }

    public void Coletar()
    {
        coletado = true;
    }
}