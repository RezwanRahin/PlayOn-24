namespace PlayOn_24.Extensions
{
	public static class FileHelper
	{
		public static string ProcessUploadedFile(this IFormFile photoFile, IWebHostEnvironment hostEnvironment)
		{
			var uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "images");
			var uniqueFileName = Guid.NewGuid().ToString() + '_' + photoFile.FileName;
			var filePath = Path.Combine(uploadsFolder, uniqueFileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				photoFile.CopyTo(fileStream);
			}

			return uniqueFileName;
		}

		public static string GetPhoto(this string? photoPath)
		{
			var noImage = "noimage.jpg";
			return "~/images/" + (photoPath ?? noImage);
		}
	}
}
