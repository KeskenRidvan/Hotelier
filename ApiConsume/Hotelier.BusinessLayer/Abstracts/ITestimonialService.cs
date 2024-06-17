using Hotelier.DtoLayer.Testimonials;

namespace Hotelier.BusinessLayer.Abstracts;

public interface ITestimonialService
{
	void Insert(TestimonialAddDto testimonialAddDto);
	void Delete(int testimonialId);
	void Update(TestimonialUpdateDto testimonialUpdateDto);
	List<TestimonialGetDto> GetList();
	TestimonialGetDto GetById(int testimonialId);
}