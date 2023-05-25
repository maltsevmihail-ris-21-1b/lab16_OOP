using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace lab16_OOP
{
    //15)	двигатель, двигатель внутреннего сгорания, дизель, турбореактивный двигатель;
    [Serializable]
    [JsonDerivedType(typeof(Engine), typeDiscriminator: "Engine")]
    [JsonDerivedType(typeof(InternalCombustionEngine), typeDiscriminator: "InternalCombustionEngine")]
    [JsonDerivedType(typeof(DiselEngine), typeDiscriminator: "DiselEngine")]
    [JsonDerivedType(typeof(TurbojetEngine), typeDiscriminator: "TurbojetEngine")]
    [XmlInclude(typeof(InternalCombustionEngine))]
    public class Engine : IRandomInit, IComparable, ICloneable<Engine>
    {
        protected int weight;
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public Engine() { }
        public Engine(int weight)
        {
            this.weight = weight;
        }
        public Engine(Engine engine)
        {
            this.weight = engine.weight;
        }
        public int CompareTo(Object? obj)
        {
            if (obj is Engine other)
                return this.Weight.CompareTo(other.Weight);
            else
                throw new ArgumentException("Object is not an Engine");
        }
        public virtual Engine RandomInit() 
        {
            this.Weight = IRandomInit.rnd.Next(100, 10000);
            return this;
        }
        public override string ToString() 
        {
            return $"{this.GetType().Name} \t\t\t\tweight: {Weight} kg";
        }
        public virtual Engine Clone()
        {
            var temp = new Engine(this.Weight);
            return temp;
        }
        public object ShallowCopy()
        {
             return MemberwiseClone();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Engine temp)
            return this.Weight == temp.Weight;
            return false;
        }
    }

    [Serializable]
    [XmlInclude(typeof(TurbojetEngine))]
    [XmlInclude(typeof(DiselEngine))]
    public class InternalCombustionEngine : Engine
    {
        protected int cost;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public InternalCombustionEngine(int _weight, int _cost) : base(_weight)
        {
            cost = _cost;
        }
        public InternalCombustionEngine() : base()
        {
            cost = 0;
        }

        public InternalCombustionEngine(InternalCombustionEngine _engine) : base(_engine)
        {
            cost = _engine.cost;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} \t\tweight: {Weight} kg\tCost: {cost}";
        }

        public override InternalCombustionEngine Clone()
        {
            var clone = new InternalCombustionEngine(base.Weight,this.Cost);
            return clone;
        }

        public override Engine RandomInit()
        {
            base.RandomInit();
            Cost = new Random().Next(100000);
            return this;
        }
    }

    [Serializable]
    public class DiselEngine : InternalCombustionEngine
    {
        private static string[] FUELS = new string[] { "summer", "winter", "arctic" };

        public string fuel
        {
            get;
            set;
        } //тип топлива
        public DiselEngine(int _weight, string _fuel, int _cost = 40000) : base(_weight, _cost)
        {
            fuel = _fuel;
        }
        public DiselEngine()
        {
            cost = 40000;
            fuel = "";
        }
        public DiselEngine(DiselEngine _engine): base(_engine)
        {
            fuel = _engine.fuel;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} \t\t\tweight: {Weight} kg\tCost: {Cost} \ttype of fuel: {fuel}";
        }
        public override DiselEngine Clone()
        {
            var temp = new DiselEngine(this.Weight, this.fuel);
            return temp;
        }
        public override Engine RandomInit()
        {
            base.RandomInit();
            fuel = FUELS[new Random().Next(FUELS.Length)];
            return this;
        }
    }

    [Serializable]
    public class TurbojetEngine : InternalCombustionEngine
    {
        public int combustionChamberVolume//объем камеры сгорания
        {
            get;
            set;
        }
        
        public TurbojetEngine(int _weight, int _combustionChamberVolume, int _cost = 70000000) : base(_weight, _cost)
        {
            combustionChamberVolume = _combustionChamberVolume;
        }
        public TurbojetEngine() : base()
        {
            Cost = 7000000;
            combustionChamberVolume = 0;
        }
        public TurbojetEngine(TurbojetEngine _engine): base(_engine)
        {
            combustionChamberVolume = _engine.combustionChamberVolume;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} \t\t\tweight: {Weight} kg\tCost: {Cost}\tCCV: {combustionChamberVolume}";
        }
        public override TurbojetEngine Clone()
        {
            var temp = new TurbojetEngine(this.Weight, this.combustionChamberVolume);
            return temp;
        }
        public override Engine RandomInit()
        {
            base.RandomInit();
            combustionChamberVolume = new Random().Next(500, 15000);
            return this;
        }
    }
}