using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Foody.BLL.Services.Clients.Models
{
    public class LogmealRecognitionResponse
    {
        public List<string> foodName { get; set; }
        public bool hasNutritionalInfo { get; set; }
        public List<int> ids { get; set; }
        public int imageId { get; set; }
        public NutritionalInfo nutritional_info { get; set; }
        public List<NutritionalInfoPerItem> nutritional_info_per_item { get; set; }
        public double serving_size { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ALC
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class CA
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class CAFFN
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class CHOCDF
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class CHOLE
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class DailyIntakeReference
    {
        public CHOCDF CHOCDF { get; set; }
        public ENERCKCAL ENERC_KCAL { get; set; }
        public FASAT FASAT { get; set; }
        public FAT FAT { get; set; }
        public NA NA { get; set; }
        public PROCNT PROCNT { get; set; }
        public SUGAR SUGAR { get; set; }

        [JsonPropertyName("SUGAR.added")]
        public SUGARAdded SUGARadded { get; set; }
    }

    public class ENERCKCAL
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class F18D3CN3
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class F20D5
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class F22D6
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FAMS
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FAPU
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FASAT
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FAT
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FATRN
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FE
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FIBTG
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FOLAC
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FOLDFE
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class FOLFD
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class K
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class MG
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class NA
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class NIA
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class NutritionalInfo
    {
        public double calories { get; set; }
        public DailyIntakeReference dailyIntakeReference { get; set; }
        public TotalNutrients totalNutrients { get; set; }
    }

    public class NutritionalInfoPerItem
    {
        public int food_item_position { get; set; }
        public bool hasNutritionalInfo { get; set; }
        public int id { get; set; }
        public NutritionalInfo nutritional_info { get; set; }
        public double serving_size { get; set; }
    }

    public class P
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class PROCNT
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class RIBF
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class SUGAR
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class SUGARAdded
    {
        public string label { get; set; }
        public string level { get; set; }
        public double percent { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class THIA
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class TOCPHA
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class TotalNutrients
    {
        public ALC ALC { get; set; }
        public CA CA { get; set; }
        public CAFFN CAFFN { get; set; }
        public CHOCDF CHOCDF { get; set; }
        public CHOLE CHOLE { get; set; }
        public ENERCKCAL ENERC_KCAL { get; set; }
        public F18D3CN3 F18D3CN3 { get; set; }
        public F20D5 F20D5 { get; set; }
        public F22D6 F22D6 { get; set; }
        public FAMS FAMS { get; set; }
        public FAPU FAPU { get; set; }
        public FASAT FASAT { get; set; }
        public FAT FAT { get; set; }
        public FATRN FATRN { get; set; }
        public FE FE { get; set; }
        public FIBTG FIBTG { get; set; }
        public FOLAC FOLAC { get; set; }
        public FOLDFE FOLDFE { get; set; }
        public FOLFD FOLFD { get; set; }
        public K K { get; set; }
        public MG MG { get; set; }
        public NA NA { get; set; }
        public NIA NIA { get; set; }
        public P P { get; set; }
        public PROCNT PROCNT { get; set; }
        public RIBF RIBF { get; set; }
        public SUGAR SUGAR { get; set; }

        [JsonPropertyName("SUGAR.added")]
        public SUGARAdded SUGARadded { get; set; }
        public THIA THIA { get; set; }
        public TOCPHA TOCPHA { get; set; }
        public VITARAE VITA_RAE { get; set; }
        public VITB12 VITB12 { get; set; }
        public VITB6A VITB6A { get; set; }
        public VITC VITC { get; set; }
        public VITD VITD { get; set; }
        public VITK1 VITK1 { get; set; }
        public ZN ZN { get; set; }
    }

    public class VITARAE
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class VITB12
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class VITB6A
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class VITC
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class VITD
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class VITK1
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    public class ZN
    {
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }


}
