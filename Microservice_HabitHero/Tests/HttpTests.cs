using NUnit.Framework;
using System.Net;

namespace Microservice_HabitHero.Tests
{
    public class HttpTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            // Cria o cliente HTTP apontando para sua API local
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7256")
            };
        }

        [Test]
        public async Task GetHabits_ReturnsOk_AndJsonResponse()
        {
            // Act
            var response = await _client.GetAsync("/habits?clientId=Daniel");

            // Assert: status 200 OK
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "O endpoint /habits deve retornar status 200.");

            // Assert: Content-Type JSON
            Assert.That(response.Content.Headers.ContentType?.MediaType,
                Is.EqualTo("application/json"),
                "A resposta deve estar no formato JSON.");

            // (Opcional) Lê o conteúdo
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(content, "A resposta JSON não deve estar vazia.");
        }

        [Test]
        public async Task GetHabits_ReturnsNotFound()
        {
            // Act
            var response = await _client.GetAsync("/habits");

            // Assert: status 200 OK
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                "O endpoint /habits deve retornar status 404.");
        }

        [Test]
        public async Task DeleteHabits_ReturnsNotFound()
        {
            // Act
            var response = await _client.DeleteAsync("/habits?=");

            // Assert: status 200 OK
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                "O endpoint /habits deve retornar status 400.");
        }
    }
}
