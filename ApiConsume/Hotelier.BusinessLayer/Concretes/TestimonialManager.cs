using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Testimonials;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class TestimonialManager : ITestimonialService
{
	private readonly ITestimonialDal _testimonialDal;
	private readonly IMapper _mapper;

	public TestimonialManager(
		ITestimonialDal testimonialDal,
		IMapper mapper)
	{
		_testimonialDal = testimonialDal;
		_mapper = mapper;
	}

	public void Delete(int testimonialId)
	{
		var deletedTestimonial = _testimonialDal.GetById(testimonialId);
		_testimonialDal.Delete(deletedTestimonial);
	}

	public TestimonialGetDto GetById(int testimonialId)
	{
		Testimonial testimonial =
			_testimonialDal.GetById(testimonialId);

		TestimonialGetDto response =
			_mapper.Map<TestimonialGetDto>(testimonial);
		return response;
	}

	public List<TestimonialGetDto> GetList()
	{
		List<Testimonial> testimonials =
			_testimonialDal.GetList();

		List<TestimonialGetDto> response =
			_mapper.Map<List<TestimonialGetDto>>(testimonials);
		return response;
	}

	public void Insert(TestimonialAddDto testimonialAddDto)
	{
		Testimonial testimonial =
			_mapper.Map<Testimonial>(testimonialAddDto);
		_testimonialDal.Insert(testimonial);
	}

	public void Update(TestimonialUpdateDto testimonialUpdateDto)
	{
		Testimonial testimonial =
		   _mapper.Map<Testimonial>(testimonialUpdateDto);

		_testimonialDal.Update(testimonial);
	}
}