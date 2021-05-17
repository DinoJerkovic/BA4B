using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BA4B
{
    class Program
    {
        public static Dictionary<string, string> create_lookup()
        {
            Dictionary<string, string> codons = new Dictionary<string, string>();
            codons["AUG"] = "M";
            codons["AUA"] = "I";
            codons["AUC"] = "I";
            codons["AUU"] = "I";
            codons["AGG"] = "R";
            codons["AGA"] = "R";
            codons["AGC"] = "S";
            codons["AGU"] = "S";
            codons["ACG"] = "T";
            codons["ACA"] = "T";
            codons["ACC"] = "T";
            codons["ACU"] = "T";
            codons["AAG"] = "K";
            codons["AAA"] = "K";
            codons["AAC"] = "N";
            codons["AAU"] = "N";

            codons["CAU"] = "H";
            codons["CAC"] = "H";
            codons["CAA"] = "Q";
            codons["CAG"] = "Q";
            codons["CCU"] = "P";
            codons["CCC"] = "P";
            codons["CCA"] = "P";
            codons["CCG"] = "P";
            codons["CGU"] = "R";
            codons["CGC"] = "R";
            codons["CGA"] = "R";
            codons["CGG"] = "R";
            codons["CUU"] = "L";
            codons["CUC"] = "L";
            codons["CUA"] = "L";
            codons["CUG"] = "L";

            codons["GAU"] = "D";
            codons["GAC"] = "D";
            codons["GAA"] = "E";
            codons["GAG"] = "E";
            codons["GCU"] = "A";
            codons["GCC"] = "A";
            codons["GCA"] = "A";
            codons["GCG"] = "A";
            codons["GGU"] = "G";
            codons["GGC"] = "G";
            codons["GGA"] = "G";
            codons["GGG"] = "G";
            codons["GUU"] = "V";
            codons["GUC"] = "V";
            codons["GUA"] = "V";
            codons["GUG"] = "V";


            codons["UAU"] = "Y";
            codons["UAC"] = "Y";
            codons["UAA"] = "*";
            codons["UAG"] = "*";
            codons["UCU"] = "S";
            codons["UCC"] = "S";
            codons["UCA"] = "S";
            codons["UCG"] = "S";
            codons["UGU"] = "C";
            codons["UGC"] = "C";
            codons["UGA"] = "*";
            codons["UGG"] = "W";
            codons["UUU"] = "F";
            codons["UUC"] = "F";
            codons["UUA"] = "L";
            codons["UUG"] = "L";

            return codons;
        }
        public static string reverse_complement(string dna)
        {
            Dictionary<string, string> lookup_dict = new Dictionary<string, string>();
            lookup_dict["A"] = "T";
            lookup_dict["C"] = "G";
            lookup_dict["G"] = "C";
            lookup_dict["T"] = "A";
            string reve = "";
            for(int i = 0; i < dna.Length; i++)
            {
                reve += lookup_dict[dna.Substring(i, 1)];
            }
            string s = "";
            for(int j = reve.Length - 1; j >= 0; j--)
            {
                s += reve.Substring(j, 1);
            }
            return s;
        }
        public static string rna_to_peptide(string rna)
        {
            string peptide = "";
            Dictionary<string, string> lookup = create_lookup();
            for(int start = 0; start < rna.Length - 2; start += 3)
            {
                if (lookup[rna.Substring(start, 3)] == "*")
                    break;
                peptide += lookup[rna.Substring(start, 3)];
            }
            return peptide;
        }
        public static string dna_to_rna(string dna)
        {
            return dna.Replace("T", "U");
        }
        public static string rna_to_dna(string rna)
        {
            return rna.Replace("U", "T");
        }
        public static List<string> substr_in_genome(string dna,string peptide)
        {
            List<string> substr = new List<string>();
            string rna = dna_to_rna(dna);
            string complement_rna = dna_to_rna(reverse_complement(dna));
            int sub_len = peptide.Length * 3;
            int start = 0;
            int dna_len = dna.Length;
            while (start + sub_len <= dna_len)
            {
                string sub_one = rna.Substring(start, sub_len);
                string sub_two = complement_rna.Substring(start, sub_len);
                if (peptide == rna_to_peptide(sub_one))
                    substr.Add(rna_to_dna(sub_one));
                if (peptide == rna_to_peptide(sub_two))
                    substr.Add(reverse_complement(rna_to_dna(sub_two)));
                start += 1;
            }
            return substr;
        }
        static void Main(string[] args)
        {
            List<string> lista = substr_in_genome("ATGGCCATGGCCCCCAGAACTGAGATCAATAGTACCCGTATTAACGGGTGA", "MA");
            foreach (string l in lista)
                Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}
