namespace PirateBattle.Domain.ValueObjects {
    public class Damage
    {
        float ammout;        
        public Damage(float ammount){
            this.ammount = ammount;
        }
        public float Ammount {
            get { 
                return ammount;
            } 
            private set; 
        }
    }
}
