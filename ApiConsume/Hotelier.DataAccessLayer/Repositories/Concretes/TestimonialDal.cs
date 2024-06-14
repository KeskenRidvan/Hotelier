using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class TestimonialDal : Repository<Testimonial>, ITestimonialDal
{
	public TestimonialDal(BaseDbContext context) : base(context)
	{
	}
}
