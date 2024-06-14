using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class TestimonialManager : ITestimonialService
{
	private readonly ITestimonialDal _testimonialDal;

	public TestimonialManager(ITestimonialDal testimonialDal)
	{
		_testimonialDal = testimonialDal;
	}

	public void Delete(Testimonial testimonial)
	{
		_testimonialDal.Delete(testimonial);
	}

	public Testimonial GetById(int testimonialId)
	{
		return _testimonialDal.GetById(testimonialId);
	}

	public List<Testimonial> GetList()
	{
		return _testimonialDal.GetList();
	}

	public void Insert(Testimonial testimonial)
	{
		_testimonialDal.Insert(testimonial);
	}

	public void Update(Testimonial testimonial)
	{
		_testimonialDal.Update(testimonial);
	}
}