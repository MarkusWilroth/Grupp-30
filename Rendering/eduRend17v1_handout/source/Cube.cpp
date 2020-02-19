//#include "Cube.h"
//
//using namespace std;
//
//Cube::Cube(ID3D11Device* dxdevice, ID3D11DeviceContext* dxdevice_context) : Geometry_t(dxdevice, dxdevice_context) {
//	vertex_t v0, v1, v2, v3, v4, v5, v6, v7;
//	v0.Pos = { -0.5, -0.5f, 0.0f };
//	v0.Normal = { 0, 0, 1 };
//	v0.TexCoord = { 0, 0 };
//
//	v1.Pos = { 0.5, -0.5f, 0.0f };
//	v1.Normal = { 0, 0, 1 };
//	v1.TexCoord = { 0, 1 };
//
//	v2.Pos = { 0.5, 0.5f, 0.0f };
//	v2.Normal = { 0, 0, 1 };
//	v2.TexCoord = { 1, 1 };
//
//	v3.Pos = { -0.5, 0.5f, 0.0f };
//	v3.Normal = { 0, 0, 1 };
//	v3.TexCoord = { 1, 0 };
//
//	/*v4.Pos = { -0.5, 0.5f, 1.0f };
//	v4.Normal = { 0, 0, 1 };
//	v4.TexCoord = { 1, 0 };
//
//	v5.Pos = { -0.5, 0.5f, 1.0f };
//	v5.Normal = { 0, 0, 1 };
//	v5.TexCoord = { 1, 0 };
//
//	v6.Pos = { -0.5, 0.5f, 1.0f };
//	v6.Normal = { 0, 0, 1 };
//	v6.TexCoord = { 1, 0 };
//
//	v7.Pos = { -0.5, 0.5f, 1.0f };
//	v7.Normal = { 0, 0, 1 };
//	v7.TexCoord = { 1, 0 };*/
//
//	vertices.push_back(v0);
//	vertices.push_back(v1);
//	vertices.push_back(v2);
//	vertices.push_back(v3);
//	/*vertices.push_back(v4);
//	vertices.push_back(v5);
//	vertices.push_back(v6);
//	vertices.push_back(v7);*/
//
//	// Populate the index array with two triangles
//	// Triangle #1
//	//indices.push_back(0);
//	//indices.push_back(1);
//	//indices.push_back(3);
//	//// Triangle #2
//	//indices.push_back(1);
//	//indices.push_back(2);
//	//indices.push_back(3);
//
//	// Vertex array descriptor
//	D3D11_BUFFER_DESC vbufferDesc = { 0.0f };
//	vbufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
//	vbufferDesc.CPUAccessFlags = 0;
//	vbufferDesc.Usage = D3D11_USAGE_DEFAULT;
//	vbufferDesc.MiscFlags = 0;
//	vbufferDesc.ByteWidth = vertices.size() * sizeof(vertex_t);
//	// Data resource
//	D3D11_SUBRESOURCE_DATA vdata;
//	vdata.pSysMem = &vertices[0];
//	// Create vertex buffer on device using descriptor & data
//	HRESULT vhr = dxdevice->CreateBuffer(&vbufferDesc, &vdata, &vertex_buffer);
//
//	//  Index array descriptor
//	D3D11_BUFFER_DESC ibufferDesc = { 0.0f };
//	ibufferDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
//	ibufferDesc.CPUAccessFlags = 0;
//	ibufferDesc.Usage = D3D11_USAGE_DEFAULT;
//	ibufferDesc.MiscFlags = 0;
//	ibufferDesc.ByteWidth = indices.size() * sizeof(unsigned);
//	// Data resource
//	D3D11_SUBRESOURCE_DATA idata;
//	idata.pSysMem = &indices[0];
//	// Create index buffer on device using descriptor & data
//	HRESULT ihr = dxdevice->CreateBuffer(&ibufferDesc, &idata, &index_buffer);
//
//	// Local data is now loaded to device so it can be released
//	vertices.clear();
//	nbr_indices = indices.size();
//	indices.clear();
//}
//
//void Cube::render() const {
//	//set topology
//	dxdevice_context->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
//
//	// bind our vertex buffer
//	UINT32 stride = sizeof(vertex_t); //  sizeof(float) * 8;
//	UINT32 offset = 0;
//	dxdevice_context->IASetVertexBuffers(0, 1, &vertex_buffer, &stride, &offset);
//
//	// bind our index buffer
//	dxdevice_context->IASetIndexBuffer(index_buffer, DXGI_FORMAT_R32_UINT, 0);
//
//	// make the drawcall
//	dxdevice_context->DrawIndexed(nbr_indices, 0, 0);
//}
//
