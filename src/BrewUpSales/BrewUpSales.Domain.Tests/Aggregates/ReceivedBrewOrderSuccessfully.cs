﻿using BrewUpSales.Domain.CommandHandlers;
using BrewUpSales.Messages.Commands;
using BrewUpSales.Messages.DomainEvents;
using BrewUpSales.Shared.BindingContracts;
using BrewUpSales.Shared.CustomTypes;
using BrewUpSales.Shared.DomainIds;
using BrewUpSales.Shared.Enums;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUpSales.Domain.Tests.Aggregates;

public sealed class ReceivedBrewOrderSuccessfully : CommandSpecification<ReceiveBrewOrder>
{
	private readonly BrewOrderId _brewOrderId = new(Guid.NewGuid());
	private readonly BrewOrderNumber _brewOrderNumber = new($"{DateTime.UtcNow.Year:0000}{DateTime.UtcNow.Month:00}{DateTime.UtcNow.Day:00}-{DateTime.UtcNow.Hour:00}{DateTime.UtcNow.Minute:00}");

	private readonly Guid _commitId = Guid.NewGuid();

	private readonly ReceivedOn _receivedOn = new(DateTime.UtcNow);
	private readonly IEnumerable<BrewOrderRow> _rows = Enumerable.Empty<BrewOrderRow>();

	protected override IEnumerable<DomainEvent> Given()
	{
		yield break;
	}

	protected override ReceiveBrewOrder When()
	{
		return new ReceiveBrewOrder(_brewOrderId, _commitId, _brewOrderNumber, _receivedOn, _rows);
	}

	protected override ICommandHandlerAsync<ReceiveBrewOrder> OnHandler()
	{
		return new ReceiveBrewOrderCommandHandlerAsync(Repository, new NullLoggerFactory());
	}

	protected override IEnumerable<DomainEvent> Expect()
	{
		yield return new BrewOrderReceived(_brewOrderId, _commitId, _brewOrderNumber, _receivedOn, _rows, BrewOrderStatus.Received);
	}
}