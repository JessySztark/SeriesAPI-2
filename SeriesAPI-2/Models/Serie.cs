using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeriesAPI.Models.EntityFramework;

[Table("serie")]
public partial class Serie
{
    public Serie()
    {

    }

    public Serie(string titre, string resume, int nbsaisons, int nbepisodes, int anneecreation, string network)
    {
        Titre = titre;
        Resume = resume;
        NbSaisons = nbsaisons;
        NbEpisodes = nbepisodes;
        AnneeCreation = anneecreation;
        Network = network;
    }

    [Key]
    [Column("serieid")]
    public int Serieid { get; set; }

    [Column("titre")]
    [StringLength(100)]
    public string Titre { get; set; } = null!;

    [Column("resume")]
    public string? Resume { get; set; }

    [Column("nbsaisons")]
    public int NbSaisons { get; set; }

    [Column("nbepisodes")]
    public int NbEpisodes { get; set; }

    [Column("anneecreation")]
    public int AnneeCreation { get; set; }

    [Column("network")]
    [StringLength(50)]
    public string? Network { get; set; }
}

