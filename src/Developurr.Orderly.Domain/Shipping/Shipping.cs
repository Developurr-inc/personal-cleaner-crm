using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Shipping.ValueObjects;

namespace Developurr.Orderly.Domain.Shipping;

public sealed partial class Shipping : Entity<ShippingId>, IAggregateRoot
{
    // private readonly List<OrderId> _orders;
    public Cnpj Cnpj { get; }
    public ActiveStatus Active { get; private set; }
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
        NonEmptyText segmento,
        ActiveStatus active
    )
        : base(shippingId)
    {
        // _orders = new List<OrderId>();
        Cnpj = cnpj;
        RazaoSocial = razaoSocial;
        InscricaoSocial = inscricaoSocial;
        NomeFantasia = nomeFantasia;
        Segmento = segmento;
        Active = active;
    }
    
    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
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
        var activeObj = ActiveStatus.Active;

        return new Shipping(
            shippingId,
            cnpjObj,
            razaoSocialObj,
            inscricaoSocialObj,
            nomeFantasiaObj,
            segmentoObj,
            activeObj
        );
    }
}
