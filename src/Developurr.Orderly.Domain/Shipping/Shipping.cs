using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Shipping.ValueObjects;

namespace Developurr.Orderly.Domain.Shipping;

public sealed class Shipping : Entity<ShippingId>, IAggregateRoot
{
    // private readonly List<OrderId> _orders;
    public Cnpj Cnpj { get; }
    public NonEmptyText RazaoSocial { get; private set; }
    public NonEmptyText InscricaoSocial { get; private set; }
    public NonEmptyText NomeFantasia { get; private set; }
    public NonEmptyText Segmento { get; private set; }

    private Shipping(
        ShippingId shippingId,
        Cnpj cnpj,
        NonEmptyText razaoSocial,
        NonEmptyText inscricaoSocial,
        NonEmptyText nomeFantasia,
        NonEmptyText segmento
    )
        : base(shippingId)
    {
        // _orders = new List<OrderId>();
        Cnpj = cnpj;
        RazaoSocial = razaoSocial;
        InscricaoSocial = inscricaoSocial;
        NomeFantasia = nomeFantasia;
        Segmento = segmento;
    }

    public static Shipping Create(
        string cnpj,
        string razaoSocial,
        string inscricaoSocial,
        string nomeFantasia,
        string segmento
    )
    {
        var shippingId = ShippingId.Generate();
        var cnpjObj = Cnpj.Create(cnpj);
        var razaoSocialObj = NonEmptyText.Create(razaoSocial);
        var inscricaoSocialObj = NonEmptyText.Create(inscricaoSocial);
        var nomeFantasiaObj = NonEmptyText.Create(nomeFantasia);
        var segmentoObj = NonEmptyText.Create(segmento);

        return new Shipping(
            shippingId,
            cnpjObj,
            razaoSocialObj,
            inscricaoSocialObj,
            nomeFantasiaObj,
            segmentoObj
        );
    }
}
