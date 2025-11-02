# Images Directory

This directory contains sample images for the Image Analysis example.

## Usage

1. Place your image files in this directory
2. The ImageAnalysis example looks for `sample.jpg` by default
3. Supported formats: JPG, PNG, GIF, BMP, and other common image formats

## Example Files

- `sample.jpg` - Default image used by the ImageAnalysis example

## Notes

- Images are converted to base64 format for API transmission
- Large images will be processed but may take longer
- The AI model can analyze various aspects of images including:
  - Objects and people in the image
  - Colors and composition
  - Text within images (OCR)
  - Scene descriptions
  - Artistic analysis

## Running the Example

```bash
dotnet run --project ImageAnalysis.csproj
```

Make sure you have a `sample.jpg` file in this directory before running the example.