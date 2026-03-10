// Model/GameModel.cs
public class GameModel
{
    public int pontuacaoTotal;
    public int objetosColetados;
    public int totalObjetivos = 9; //

    public void AdicionarPontos(int valor)
    {
        pontuacaoTotal += valor;
        objetosColetados++;
    }

    public bool FaseCompleta()
    {
        return objetosColetados >= totalObjetivos;
    }
}