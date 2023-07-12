class Camioneta : Veiculo{
    #region attributes
    private int quantAxis;
    private int maxPassengers;
    #endregion

    #region getset
    public int QuantAxis{
        get{
            return quantAxis;
        }
        set{
            quantAxis = value;
        }
    }

    public int MaxPassengers{
        get{
            return maxPassengers;
        }
        set{
            maxPassengers = value;
        }
    }
    #endregion

    #region constructors
    public Camioneta(){
        quantAxis = 0;
        maxPassengers = 0;
    }

    public Camioneta(string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int quantAxis, int maxPassengers) : base(marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia){
        this.quantAxis = quantAxis;
        this.maxPassengers = maxPassengers;
    }
    #endregion

}