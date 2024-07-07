using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Bookings;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;
public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;
    private readonly IMapper _mapper;

    public BookingManager(
        IBookingDal bookingDal,
        IMapper mapper)
    {
        _bookingDal = bookingDal;
        _mapper = mapper;
    }

    public void Delete(int bookingId)
    {
        var deletedBooking = _bookingDal.GetById(bookingId);
        _bookingDal.Delete(deletedBooking);
    }

    public BookingGetDto GetById(int bookingId)
    {
        Booking booking =
            _bookingDal.GetById(bookingId);

        BookingGetDto response =
            _mapper.Map<BookingGetDto>(booking);
        return response;
    }

    public List<BookingGetDto> GetList()
    {
        List<Booking> bookings =
            _bookingDal.GetList();

        List<BookingGetDto> response =
            _mapper.Map<List<BookingGetDto>>(bookings);
        return response;
    }

    public void Insert(BookingAddDto bookingAddDto)
    {
        Booking booking =
            _mapper.Map<Booking>(bookingAddDto);
        _bookingDal.Insert(booking);
    }

    public void Update(BookingUpdateDto bookingUpdateDto)
    {
        Booking booking =
           _mapper.Map<Booking>(bookingUpdateDto);

        _bookingDal.Update(booking);
    }

    public void BookingUpdateStatus(BookingUpdateStatus bookingUpdateStatus)
    {
        var booking =
                _bookingDal.GetById(bookingUpdateStatus.BookingID);

        booking.Status = bookingUpdateStatus.Status;

        _bookingDal.Update(booking);
    }

    public int GetBookingCount()
    {
        return _bookingDal.GetBookingCount();
    }

    public List<BookingGetDto> Last6Bookings()
    {
        List<Booking> bookings =
             _bookingDal.Last6Bookings();

        List<BookingGetDto> response =
            _mapper.Map<List<BookingGetDto>>(bookings);

        return response;
    }
}