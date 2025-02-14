﻿using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Artists
{
	/// <summary>
	/// Command handler for artist modification.
	/// </summary>
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Artist Artist { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _dataContext;
			private readonly IMapper _mapper;

			public Handler(DataContext dataContext, IMapper mapper)
			{
				_dataContext = dataContext;
				_mapper = mapper;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				try
				{
					var artist = await _dataContext.Artists.SingleOrDefaultAsync(id => id.ArtistId == request.Artist.ArtistId);

					if (artist == null) return Result<Unit>.Failure("Artist not found");

					_mapper.Map(request.Artist, artist);

					var result = await _dataContext.SaveChangesAsync() > 0;

					if (!result) return Result<Unit>.Failure("Failed to update Artist");

					return Result<Unit>.Success(Unit.Value);
				}
				catch
				{
					return Result<Unit>.Failure("Failed to update Artist");
				}
				
			}
		}
	}
}
