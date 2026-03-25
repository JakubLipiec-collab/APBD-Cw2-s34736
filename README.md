•	W README wskaż, gdzie w projekcie widać próbę zadbania o kohezję, coupling i odpowiedzialności klas.
- kohezja: Klasa MemoryRepository.cs skupie sie wylacznie na zarzadzaniu kolekcjami danych (Zapis i odczyt)i tylko na tym
- coupling: Klasa RentalService.cs nie tworzy wlasnej bazy danych, tylko przyjmuje gotowy obiekt przez konstruktor
- odpowiedzialność: Klasa RentalService.cs odpowiada tylko za zasady biznesowe, a Program.cs tylko za ui
•	W README krótko uzasadnij, dlaczego wybrałeś taki podział klas, plików i ewentualnych warstw projektu
- Podzial na dedykowane warstwy (Models na dane, Repositories dla magazynu, Services dla logiki) ulatwia czytanie kodu oraz poruszania sie po nim, co wspomaga szukanie bledow
