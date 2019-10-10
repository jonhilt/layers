using System;
using NeoFindR.Domain;
using NeoFindR.Features.Inhabitants;
using Shouldly;
using Xunit;

namespace NeoFindR.Specs.Inhabitants
{
    public class WhenDestroyingAnInhabitant : IntegrationTestBase
    {
        [Fact]
        public async void TheyShouldBeCompletelyExpunged()
        {
            // arrange
            var inhabitantId = Guid.NewGuid();
            await SliceFixture.InsertAsync(new Inhabitant {Id = inhabitantId});

            // act
            await SliceFixture.SendAsync(new Destroy.Command {Id = inhabitantId});

            // assert
            var savedInhabitant = await SliceFixture.FindAsync<Inhabitant>(inhabitantId);
            savedInhabitant.ShouldBeNull();
        }
    }
}