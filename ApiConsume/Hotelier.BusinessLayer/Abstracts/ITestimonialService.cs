using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Abstracts;

public interface ITestimonialService
{
	void Insert(Testimonial testimonial);
	void Delete(Testimonial testimonial);
	void Update(Testimonial testimonial);
	List<Testimonial> GetList();
	Testimonial GetById(int testimonialId);
}