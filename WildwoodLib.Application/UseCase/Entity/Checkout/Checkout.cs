namespace WildwoodLib.Application.UseCase.Entity.Checkout
{
    public class Checkout
    {
        public interface IGetCheckoutQuery : IQuery<CheckoutSearchDto, PagedResponse<CheckoutDto>> { }
        public interface IGetUserCheckoutQuery : IQuery<UserCheckoutSearchDto, PagedResponse<CheckoutDto>> { }
        public interface ICreateCheckoutCommand : ICommand<CreateCheckoutDto> { }
        public interface IUpdateCheckoutCommand : ICommand<UpdateCheckoutDto> { }
        public interface IDeleteCheckoutCommand : ICommand<DeleteCheckoutDto> { }
    }
}
