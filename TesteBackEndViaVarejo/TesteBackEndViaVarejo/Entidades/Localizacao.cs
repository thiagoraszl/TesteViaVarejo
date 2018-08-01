namespace TesteBackEndViaVarejo.Entidades
{
    public class Localizacao
    {
        private readonly int _latitude;
        private readonly int _longitude;

        public Localizacao(int latitude, int longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        public int Latitude
        {
            get { return _latitude; }
        }

        public int Longitude
        {
            get { return _longitude; }
        }
    }
}
